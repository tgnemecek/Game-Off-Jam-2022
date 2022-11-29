using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InHand : CardState
{
  bool _lastHoverState = false;
  Camera _camera = Camera.main;

  public CardState_InHand(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.DrawnOnThisFrame = false;
    _context.CardLayerController.SetDefaultLayer();
    _context.CardLayerController.ToggleShadow(false);
    _context.CardAudio.PlayCardDrawn();
    MoveToHandPosition();
    RotateToHand();
  }
  public override void UpdateState()
  {
    base.CheckCardSide(_camera);
    DetectClick();
    DetectPositionChangeInHand();
  }

  void DetectClick()
  {
    if (!PlayerController.Instance.CanInteractWithCards) return;
    if (!_context.IsHovering) return;

    if (Input.GetMouseButtonDown(0))
    {
      SwitchState(_factory.Dragged());
      return;
    }
  }

  void DetectPositionChangeInHand()
  {
    if (_context.PositionChangedThisFrame)
    {
      _context.PositionChangedThisFrame = false;
      MoveToHandPosition();
    }
  }

  void ScaleToHandSize()
  {
    CardConfig cardConfig = _context.CardConfig;

    LeanTween.scale(_context.gameObject, Vector3.one, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
    LeanTween.moveLocalY(_context.gameObject, 0f, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
  }

  void MoveToHandPosition()
  {
    LeanTween.move(_context.gameObject, _context.PositionInHand, _context.CardConfig.MovementToHandTime).setEaseInOutCubic();
  }

  void RotateToHand()
  {
    float targetX = _camera.transform.rotation.eulerAngles.x;
    Quaternion rotation = Quaternion.Euler(targetX, 0, 0);

    LeanTween.rotate(_context.gameObject, rotation.eulerAngles, _context.CardConfig.MovementToHandTime).setEaseInOutCubic();
  }

  public override void FixedUpdateState()
  {
    if (!PlayerController.Instance.CanInteractWithCards) return;

    bool hoveringThisCard = _context.IsHovering && !PlayerController.Instance.CardBeingDragged;

    if (_lastHoverState == false && hoveringThisCard) OnHoverStart();
    else if (_lastHoverState == true && !hoveringThisCard) OnHoverEnd();
    _lastHoverState = hoveringThisCard;
  }

  void OnHoverStart()
  {
    _context.CardLayerController.SetCloseUpLayer();

    CardConfig cardConfig = _context.CardConfig;

    LeanTween.scale(_context.gameObject, _context.transform.localScale * cardConfig.ScaleOnHover, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
    LeanTween.moveLocalY(_context.gameObject, cardConfig.OffsetYOnHover, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
  }

  void OnHoverEnd()
  {
    _context.CardLayerController.SetDefaultLayer();
    ScaleToHandSize();
  }

  public override void ExitState()
  {
    _context.CardLayerController.ToggleShadow(true);
  }
}