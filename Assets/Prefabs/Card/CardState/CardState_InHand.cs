using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InHand : CardState
{
  bool _isHovering = false;
  bool _isHoveringQueued = false;
  Camera _camera = Camera.main;

  public CardState_InHand(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.DrawnOnThisFrame = false;
    _isHoveringQueued = false;
    ScaleToHandSize();
    MoveToHandPosition();
    RotateToHand();
  }
  public override void UpdateState()
  {
    CheckCardSide();
    DetectClick();
    CheckForQueuedHover();
    DetectPositionChangeInHand();
  }

  void CheckCardSide()
  {
    _context.CardLayerController.ShowCardFront();
    // float dot = Vector3.Dot(_context.transform.forward, (_camera.transform.position - _context.transform.position).normalized);
    // bool facingCamera = dot > .7f;




    // // float absRotationY = Mathf.Abs(_context.transform.rotation.eulerAngles.y);

    // // bool facingCamera = absRotationY < 90;

    // if (facingCamera)
    // {
    //   _context.CardLayerController.ShowCardFront();
    //   return;
    // }
    // _context.CardLayerController.ShowCardBack();
  }

  void DetectClick()
  {
    if (!_isHovering) return;
    if (PlayerController.Instance.IsDraggingCard) return;

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
    LeanTween.rotate(_context.gameObject, Vector3.zero, _context.CardConfig.MovementToHandTime).setEaseInOutCubic();
  }

  public override void FixedUpdateState() { }
  public override void OnMouseEnter()
  {
    if (PlayerController.Instance.IsDraggingCard)
    {
      _isHoveringQueued = true;
      return;
    }
    OnHoverStart();
  }

  void CheckForQueuedHover()
  {
    if (!_isHoveringQueued) return;

    if (!PlayerController.Instance.IsDraggingCard) OnHoverStart();
  }

  void OnHoverStart()
  {
    _isHovering = true;
    _isHoveringQueued = false;
    _context.CardLayerController.SetDraggedLayer();

    CardConfig cardConfig = _context.CardConfig;

    LeanTween.scale(_context.gameObject, _context.transform.localScale * cardConfig.ScaleOnHover, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
    LeanTween.moveLocalY(_context.gameObject, cardConfig.OffsetYOnHover, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
  }

  public override void OnMouseExit()
  {
    _isHovering = false;
    _isHoveringQueued = false;
    _context.CardLayerController.SetDefaultLayer();
    ScaleToHandSize();
  }
  public override void ExitState() { }
}