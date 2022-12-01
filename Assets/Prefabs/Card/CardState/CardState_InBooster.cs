using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBooster : CardState
{
  bool _lastHoverState = false;

  public CardState_InBooster(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    _context.CardLayerController.ShowCardFront();
    _context.CardLayerController.SetCloseUpLayer();
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


  void OnHoverEnd()
  {
    _context.CardLayerController.ToggleHoverOutline(false);

  }

  void OnHoverStart()
  {
    _context.CardLayerController.ToggleHoverOutline(true);
  }

  public override void FixedUpdateState()
  {
    if (_lastHoverState == false && _context.IsHovering) OnHoverStart();
    else if (_lastHoverState == true && !_context.IsHovering) OnHoverEnd();
    _lastHoverState = _context.IsHovering;
  }
  public override void ExitState()
  {
    OnHoverEnd();
  }
  public override bool CanBeTargeted() => false;
}