using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBoard : CardState
{
  bool _lastHoverState = false;

  public CardState_InBoard(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    GameManager.Instance.Hand.RemoveCard(_context);
    GameManager.Instance.Board.AddCardToBoard(_context);
    _context.Play();
    _context.CardLayerController.SetDefaultLayer();

    if (!_context.WasPlayed)
    {
      _context.CardAudio.PlayCardPlayed();
    }

    _context.CardAudio.PlayCardTouchBoard();

    _context.WasPlayed = true;
    PositionCard();
    OnHoverStart();
  }

  void DetectClick()
  {
    if (!_context.IsHovering) return;

    if (Input.GetMouseButtonDown(0))
    {
      SwitchState(_factory.Dragged());
      return;
    }
  }

  void PositionCard()
  {
    Vector3 basePosition = _context.LastValidBoardPosition;
    float offset = _context.CardConfig.DistanceToBoardWhenPlaced;
    float time = _context.CardConfig.TimeToPlaceOnBoard;

    float y = basePosition.y - offset;
    float z = basePosition.z + offset;

    var target = new Vector3(
      basePosition.x,
      y,
      z
    );

    LeanTween.move(_context.gameObject, target, time).setEaseInCubic();
  }

  void OnHoverEnd()
  {
    _context.CardLayerController.ToggleHoverOutline(false);

  }

  void OnHoverStart()
  {
    _context.CardLayerController.ToggleHoverOutline(true);
  }

  public override void UpdateState()
  {
    if (DetectDestroyed()) return;

    if (PlayerController.Instance.CanInteractWithCards) DetectClick();
  }
  public override void FixedUpdateState()
  {
    if (!PlayerController.Instance.CanInteractWithCards) return;

    if (_lastHoverState == false && _context.IsHovering) OnHoverStart();
    else if (_lastHoverState == true && !_context.IsHovering) OnHoverEnd();
    _lastHoverState = _context.IsHovering;
  }
  public override void ExitState()
  {
    GameManager.Instance.Board.RemoveCardFromBoard(_context);
  }
  public override void Draw() { }
  public override bool CanBeTargeted() => true;
}