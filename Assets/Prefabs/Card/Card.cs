using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Card : MonoBehaviour
{
  [SerializeField]
  private string _name;
  [SerializeField]
  private int _woodCost = 0;
  [SerializeField]
  private int _stoneCost = 0;
  [SerializeField]
  private CardConfig _cardConfig; public CardConfig CardConfig => _cardConfig;

  [SerializeField]
  private TextMeshProUGUI _nameText; public TextMeshProUGUI NameText => _nameText;
  [SerializeField]
  private CardLayerController _cardLayerController; public CardLayerController CardLayerController => _cardLayerController;

  protected ResourcesManager _resourcesManager;
  protected Hand _hand;
  private Dictionary<Resource, int> _cost = new Dictionary<Resource, int>(); public Dictionary<Resource, int> Cost => _cost;

  private CardStateFactory _stateFactory;
  private CardState _currentState; public CardState CurrentState { set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }
  private bool _isHovering; public bool IsHovering => _isHovering;
  private Vector3 _positionInHand; public Vector3 PositionInHand => _positionInHand;

  public void Draw(ResourcesManager resourcesManager, Hand hand, Vector3 positionInHand)
  {
    _drawnOnThisFrame = true;
    _cost.Add(Resource.Wood, _woodCost);
    _cost.Add(Resource.Stone, _stoneCost);
    _nameText.text = _name;
    _resourcesManager = resourcesManager;
    _hand = hand;
    _positionInHand = positionInHand;
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

  void Update() => _currentState.UpdateState();
  void FixedUpdate() => _currentState.FixedUpdateState();

  public abstract void Play();
  public abstract void EndOfTurn();
}