using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InHand : CardState
{
  bool _isHovering = false;


  public CardState_InHand(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.DrawnOnThisFrame = false;
    ScaleToHandSize();
    MoveToHandPosition();
  }
  public override void UpdateState()
  {
    CheckCardSide();
    DetectClick();
  }

  void CheckCardSide()
  {
    float absRotationY = Mathf.Abs(_context.transform.rotation.eulerAngles.y);
    _context.NameText.gameObject.SetActive(absRotationY < 90);
  }

  void DetectClick()
  {
    if (!_isHovering) return;

    if (Input.GetMouseButtonDown(0))
    {
      SwitchState(_factory.Dragged());
      return;
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

  public override void FixedUpdateState() { }
  public override void OnMouseEnter()
  {
    _isHovering = true;
    _context.CardLayerController.SetDraggedLayer();

    CardConfig cardConfig = _context.CardConfig;

    LeanTween.scale(_context.gameObject, _context.transform.localScale * cardConfig.ScaleOnHover, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
    LeanTween.moveLocalY(_context.gameObject, cardConfig.OffsetYOnHover, cardConfig.ScaleOnHoverTime).setEaseInOutCubic();
  }
  public override void OnMouseExit()
  {
    _isHovering = false;
    _context.CardLayerController.SetDefaultLayer();
    ScaleToHandSize();
  }
  public override void ExitState() { }
}