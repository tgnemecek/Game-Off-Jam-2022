using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBooster : CardState
{
  public CardState_InBooster(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    _context.CardLayerController.ShowCardFront();
  }

  public override void UpdateState()
  {
    DetectPositionChange();
    DetectClick();
  }

  void DetectPositionChange()
  {
    if (_context.PositionChangedThisFrame)
    {
      _context.PositionChangedThisFrame = false;
      MoveToHandPosition();
    }
  }

  void DetectClick()
  {
    if (!_context.IsHovering) return;

    if (Input.GetMouseButtonDown(0))
    {
      GameManager.Instance.OnCardSelected(_context);
      SwitchState(_factory.InPile());
      return;
    }
  }

  void MoveToHandPosition()
  {
    LeanTween.move(_context.gameObject, _context.PositionInHand, _context.CardConfig.MovementToHandTime).setEaseInOutCubic();
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
}