using UnityEngine;
using UnityEditor;

public enum CardTypes
{
  Resource = 0,
  Unit = 10,
  Item = 20,
  Spell = 30,
  Building = 40,
}

public enum CardInitializer
{
  Pile,
  BoosterPack
}

public abstract class Card : MonoBehaviour, IHitable
{
  public static bool IsConsumableCardType(CardTypes type)
  {
    if (type == CardTypes.Resource) return true;
    if (type == CardTypes.Item) return true;
    if (type == CardTypes.Spell) return true;
    return false;
  }

  public int Id { get; set; }

  public string Name { get; set; }

  public string Description { get; set; }

  private string _Image; public string Image
  {
    get { return _Image; }
    set
    {
      if (_cardLayerController)
      {
        _cardLayerController.SetCardImage(Resources.Load<Sprite>(value));
      }
      _Image = value;
    }
  }

  public int WoodCost { get; set; }

  public int FishCost { get; set; }

  public int GoldCost { get; set; }

  private int _hp; public int HP => _hp;
  public int MaxHP { get; set; }

  public CardTypes Type { get; set; }

  [Header("Dependencies")]
  [SerializeField]
  private CardConfig _cardConfig; public CardConfig CardConfig => _cardConfig;
  [SerializeField]
  private CardLayerController _cardLayerController; public CardLayerController CardLayerController => _cardLayerController;
  [SerializeField]
  private CardProximityDetector _cardProximityDetector; public CardProximityDetector CardProximityDetector => _cardProximityDetector;
  [SerializeField]
  private Collider _collider;
  [SerializeField]
  private HealthBar _healthBar;
  [HideInInspector]
  public CardAudio CardAudio;
  [Header("Debug Options")]
  public string CurrentStateName;

  private ResourcesDictionary _resourcesCostDictionary; public ResourcesDictionary ResourcesCostDictionary => _resourcesCostDictionary;

  protected CardStateFactory _stateFactory;
  private CardState _currentState; public CardState CurrentState { set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }
  private Vector3 _positionInHand; public Vector3 PositionInHand => _positionInHand;
  private bool _positionChangedThisFrame; public bool PositionChangedThisFrame { get { return _positionChangedThisFrame; } set { _positionChangedThisFrame = value; } }
  private bool _wasPlayed = false; public bool WasPlayed { get { return _wasPlayed; } set { _wasPlayed = value; } }
  private CardInitializer _cardInitializer; public CardInitializer CardInitializer => _cardInitializer;
  private bool _wasInitialized = false; public bool WasInitialized => _wasInitialized;
  public Vector3 DefaultScale { get; set; }
  public Vector3 LastValidBoardPosition { get; set; }
  public bool Invulnerable { get; set; }

#if UNITY_EDITOR
  void Reset()
  {
    InjectDefaultDependencies();
  }

  public void InjectDefaultDependencies()
  {
    string[] cardConfigs = AssetDatabase.FindAssets("t:CardConfig", null);

    if (cardConfigs.Length > 0)
    {
      var path = AssetDatabase.GUIDToAssetPath(cardConfigs[0]);
      _cardConfig = AssetDatabase.LoadAssetAtPath<CardConfig>(path);
    }
  }
#endif

  public void Draw() => _drawnOnThisFrame = true;

  public void SetPositionInHand(Vector3 positionInHand)
  {
    _positionInHand = positionInHand;
    _positionChangedThisFrame = true;
  }

  void Awake()
  {
    _cardLayerController = GetComponentInChildren<CardLayerController>();
    _cardProximityDetector = GetComponentInChildren<CardProximityDetector>();
    _healthBar = GetComponentInChildren<HealthBar>();
    _collider = GetComponent<Collider>();
    CardAudio = GetComponent<CardAudio>();
  }

  void Start()
  {
    _stateFactory = new CardStateFactory(this);
    _currentState = _stateFactory.NotInPlay();
    _currentState.EnterState();
  }

  public void Initialize(CardInitializer cardInitializer)
  {
    _cardInitializer = cardInitializer;
    _resourcesCostDictionary = new ResourcesDictionary(WoodCost, FishCost, GoldCost);
    CardLayerController.Initialize(Name, Resources.Load<Sprite>(Image), Description, _resourcesCostDictionary, _cardConfig);
    CardProximityDetector.Initialize(this);
    DefaultScale = transform.localScale;
    _healthBar.Initialize(transform, MaxHP, false);
    _wasInitialized = true;
    _hp = MaxHP;
  }

  public bool IsHovering => PlayerController.Instance.CardPointedTo == this;

  void Update()
  {
    _currentState.UpdateState();
    CurrentStateName = _currentState.GetType().Name;
  }
  void FixedUpdate() => _currentState.FixedUpdateState();

  public abstract void Play();

  public void ReceiveDamage(int damage)
  {
    if (Invulnerable) return;

    _hp -= damage;
    if (_hp < 0f) _hp = 0;
    _healthBar.UpdateHealth(_hp);
    CardAudio.PlayCardAttacked();
  }

  public void Heal(int amount)
  {
    _hp += amount;
    if (_hp > MaxHP) _hp = MaxHP;
    _healthBar.UpdateHealth(_hp);
  }

  public bool CanBeTargeted()
  {
    if (_currentState == null) return false;
    return _currentState.CanBeTargeted();
  }

  protected bool SnapToBoard(Camera camera)
  {
    if (PlayerController.Instance.IsHoveringOnHand && !WasPlayed)
    {
      _cardLayerController.SetCloseUpLayer();
      return SnapToScreen(camera);
    }

    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;

    Vector3 worldPos = transform.position;
    Quaternion rotation = transform.rotation;

    if (Physics.Raycast(ray, out hitInfo, 9999, GameManager.Instance.GameConfig.BoardLayerMask))
    {
      worldPos = hitInfo.point;
      rotation = hitInfo.collider.transform.rotation;
    }

    transform.position = Vector3.Lerp(
      transform.position,
      worldPos,
      CardConfig.CatchUpSpeedWhileDragging
    );
    transform.rotation = Quaternion.Lerp(
      transform.rotation,
      rotation,
      CardConfig.CatchUpSpeedWhileDragging
    );
    _cardLayerController.SetOnBoardLayer();

    var distance = transform.position - worldPos;
    return (distance.magnitude < 0.1f);
  }

  protected bool SnapToScreen(Camera camera)
  {
    float targetX = camera.transform.rotation.eulerAngles.x;
    Quaternion rotation = Quaternion.Euler(targetX, 0, 0);

    Vector3 screenPos = new Vector3(
      Input.mousePosition.x,
      Input.mousePosition.y,
      camera.WorldToScreenPoint(PositionInHand).z
    );

    Vector3 worldPos = camera.ScreenToWorldPoint(screenPos);

    transform.position = Vector3.Lerp(
      transform.position,
      worldPos,
      CardConfig.CatchUpSpeedWhileDragging
    );
    transform.rotation = Quaternion.Lerp(
      transform.rotation,
      rotation,
      CardConfig.CatchUpSpeedWhileDragging
    );
    return true;
  }

  public abstract CardState OnConsume();
  public abstract bool Drag(Camera camera);
  public Collider GetCollider() => _collider;
  public Transform GetTransform() => transform;
}