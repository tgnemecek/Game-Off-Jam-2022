using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

  protected Hand _hand; public Hand Hand => _hand;
  private ResourceCostDictionary _cost = new ResourceCostDictionary(); public ResourceCostDictionary Cost => _cost;

  private CardStateFactory _stateFactory;
  private CardState _currentState; public CardState CurrentState { set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }
  private bool _isHovering; public bool IsHovering => _isHovering;
  private Vector3 _positionInHand; public Vector3 PositionInHand => _positionInHand;
  private bool _positionChangedThisFrame; public bool PositionChangedThisFrame { get { return _positionChangedThisFrame; } set { _positionChangedThisFrame = value; } }

  public void Draw(Hand hand)
  {
    _drawnOnThisFrame = true;
    _cost.Add(Resource.Wood, WoodCost);
    _cost.Add(Resource.Stone, StoneCost);
    _nameText.text = Name;
    _hand = hand;
  }

  public void SetPositionInHand(Vector3 positionInHand)
  {
    _positionInHand = positionInHand;
    _positionChangedThisFrame = true;
  }

  void Awake()
  {
    _nameText.gameObject.SetActive(false);
  }

  void Start()
  {
    _stateFactory = new CardStateFactory(this);
    _currentState = _stateFactory.NotInPlay();
    _currentState.EnterState();
  }

  void OnMouseEnter() => _currentState.OnMouseEnter();
  void OnMouseExit() => _currentState.OnMouseExit();

  void Update()
  {
    _currentState.UpdateState();
  }
  void FixedUpdate() => _currentState.FixedUpdateState();

  public abstract void Play();
  public abstract void EndOfTurn();
}