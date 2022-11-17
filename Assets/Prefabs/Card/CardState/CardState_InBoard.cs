using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBoard : CardState
{
  bool _lastHoverState = false;

  public CardState_InBoard(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.Hand.OnCardPlayed(_context);
    _context.CardLayerController.SetDefaultLayer();
    _context.CanReturnToHand = false;
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
    DetectClick();
  }
  public override void FixedUpdateState()
  {
    if (_lastHoverState == false && _context.IsHovering) OnHoverStart();
    else if (_lastHoverState == true && !_context.IsHovering) OnHoverEnd();
    _lastHoverState = _context.IsHovering;
  }
  public override void ExitState() { }
}