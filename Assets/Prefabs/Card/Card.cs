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
  [SerializeField]
  private string _id;
  [SerializeField]
  private string _name;
  [SerializeField]
  private int _woodCost = 0;
  [SerializeField]
  private int _stoneCost = 0;
  [SerializeField]
  private CardConfig _cardConfig; public CardConfig CardConfig => _cardConfig;
  [SerializeField]
  private CardTypes _type;

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

  public Card(CardTypes type, string name, int woodCost, int stoneCost)
  {
    _type = type;
    _name = name;
    _woodCost = woodCost;
    _stoneCost = stoneCost;
  }

  public void Draw(Hand hand)
  {
    _drawnOnThisFrame = true;
    _cost.Add(Resource.Wood, _woodCost);
    _cost.Add(Resource.Stone, _stoneCost);
    _nameText.text = _name;
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