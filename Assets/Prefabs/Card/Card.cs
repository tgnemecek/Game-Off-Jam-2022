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

  #region - Layout control
  [SerializeField]
  private Canvas _canvas;
  
  [SerializeField]
  private Image _backImage; public Image BackImage => _backImage;

  [SerializeField]
  private string _draggedSortingLayerName;
  private int _defaultSortingLayerID;
  #endregion


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

  #region - Layout Control
  public void showFront() {
    _backImage.gameObject.SetActive(false);
    _nameText.gameObject.SetActive(true);
  }

  public void showBack() {
    _backImage.gameObject.SetActive(true);
    _nameText.gameObject.SetActive(false);
  }

  public void SetLayerDragged()
  {
    _canvas.sortingLayerName = _draggedSortingLayerName;
  }

  public void SetLayerDefault()
  {
    _canvas.sortingLayerID = _defaultSortingLayerID;
  }
  #endregion

  void Awake()
  {
    _nameText.gameObject.SetActive(false);
  }

  void Start()
  {
    _defaultSortingLayerID = _canvas.sortingLayerID;

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