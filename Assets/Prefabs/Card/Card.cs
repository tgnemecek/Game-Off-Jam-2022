using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public enum CardTypes
{
  Resource = 0,
  Unit = 10,
  Item = 20,
  Spell = 30,
  Building = 40,
}

public abstract class Card : MonoBehaviour
{
  public int Id { get; set; }

  public string Name { get; set; }

  public string Description { get; set; }

  public string Image { get; set; }

  public int WoodCost { get; set; }

  public int StoneCost { get; set; }

  public CardTypes Type { get; set; }

  public CardConfig _cardConfig; public CardConfig CardConfig => _cardConfig;

  [SerializeField]
  private TextMeshProUGUI _nameText; public TextMeshProUGUI NameText => _nameText;
  [SerializeField]
  private CardLayerController _cardLayerController; public CardLayerController CardLayerController => _cardLayerController;
  [SerializeField]
  private SpriteRenderer _backSprite; public SpriteRenderer BackSprite => _backSprite;
  [SerializeField]
  private SpriteRenderer _onHoverSprite; public SpriteRenderer OnHoverSprite => _onHoverSprite;

  protected Hand _hand; public Hand Hand => _hand;
  private ResourceCostDictionary _cost = new ResourceCostDictionary(); public ResourceCostDictionary Cost => _cost;

  private CardStateFactory _stateFactory;
  private CardState _currentState; public CardState CurrentState { set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }
  private bool _isHovering; public bool IsHovering => _isHovering;
  private Vector3 _positionInHand; public Vector3 PositionInHand => _positionInHand;
  private bool _positionChangedThisFrame; public bool PositionChangedThisFrame { get { return _positionChangedThisFrame; } set { _positionChangedThisFrame = value; } }
  private bool _canReturnToHand = true; public bool CanReturnToHand { get { return _canReturnToHand; } set { _canReturnToHand = value; } }

  void Reset()
  {
    InjectDefaultDependencies();
  }

  public void InjectDefaultDependencies()
  {
    void InjectCardConfig()
    {
      string[] cardConfigs = AssetDatabase.FindAssets("t:CardConfig", null);

      if (cardConfigs.Length > 0)
      {
        var path = AssetDatabase.GUIDToAssetPath(cardConfigs[0]);
        _cardConfig = AssetDatabase.LoadAssetAtPath<CardConfig>(path);
      }
    }
    void InjectNameText()
    {
      _nameText = GetComponentInChildren<TextMeshProUGUI>();
      _nameText.text = Name;
    }
    void InjectCardLayerController()
    {
      _cardLayerController = GetComponentInChildren<CardLayerController>();
    }
    void InjectCardSprites()
    {
      var sprites = GetComponentsInChildren<SpriteRenderer>();
      foreach (var sprite in sprites)
      {
        if (sprite.gameObject.name == "Sprite Back")
        {
          _backSprite = sprite;
        }
        if (sprite.gameObject.name == "Sprite OnHover")
        {
          _onHoverSprite = sprite;
        }
      }
    }

    InjectCardConfig();
    InjectNameText();
    InjectCardLayerController();
    InjectCardSprites();
  }


  public void Draw(Hand hand)
  {
    _drawnOnThisFrame = true;
    _hand = hand;
  }

  public void SetPositionInHand(Vector3 positionInHand)
  {
    _positionInHand = positionInHand;
    _positionChangedThisFrame = true;
  }

  void Awake()
  {
    _cost.Add(Resource.Wood, WoodCost);
    _cost.Add(Resource.Stone, StoneCost);
    _nameText.text = Name;
    _nameText.gameObject.SetActive(false);
  }

  void Start()
  {
    _stateFactory = new CardStateFactory(this);
    _currentState = _stateFactory.NotInPlay();
    _currentState.EnterState();
  }

  public void ShowCardBack()
  {
    _backSprite.gameObject.SetActive(true);
    _nameText.gameObject.SetActive(false);
  }

  public void ShowCardFront()
  {
    _backSprite.gameObject.SetActive(false);
    _nameText.gameObject.SetActive(true);
  }

  public void MouseEnter() => _currentState.OnMouseEnter();
  public void MouseExit() => _currentState.OnMouseExit();

  void Update()
  {
    _currentState.UpdateState();
  }
  void FixedUpdate() => _currentState.FixedUpdateState();

  public abstract void Play();
  public abstract void EndOfTurn();
}