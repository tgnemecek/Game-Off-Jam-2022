using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBoard : CardState
{
  bool _isHovering = false;
  bool _isHoveringQueued = false;

  public CardState_InBoard(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.Hand.OnCardPlayed(_context);
    _context.CanReturnToHand = false;
    _isHovering = true;
    _isHoveringQueued = false;
    PositionCard();
    OnHoverStart();
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

  void PositionCard()
  {
    float offset = _context.CardConfig.DistanceToBoardWhenPlaced;
    float time = _context.CardConfig.TimeToPlaceOnBoard;

    float y = _context.transform.position.y - offset;
    float z = _context.transform.position.z + offset;

    var target = new Vector3(
      _context.transform.position.x,
      y,
      z
    );

    LeanTween.move(_context.gameObject, target, time).setEaseInCubic();
  }

  void CheckForQueuedHover()
  {
    if (!_isHoveringQueued) return;

    if (!PlayerController.Instance.IsDraggingCard) OnHoverStart();
  }

  public override void OnMouseEnter()
  {
    if (PlayerController.Instance.IsDraggingCard)
    {
      _isHoveringQueued = true;
      return;
    }
    OnHoverStart();
  }

  public override void OnMouseExit()
  {
    _isHovering = false;
    _isHoveringQueued = false;

    _context.OnHoverSprite.transform.localScale = Vector3.one;
  }

  void OnHoverStart()
  {
    _isHovering = true;
    _isHoveringQueued = false;

    float offsetSize = _context.CardConfig.OnBoardHoverOutlineSize;

    float x = _context.BackSprite.transform.localScale.x + offsetSize;
    float y = _context.BackSprite.transform.localScale.y + offsetSize;

    _context.OnHoverSprite.transform.localScale = new Vector3(x, y, 1);
  }


  public override void UpdateState()
  {
    DetectClick();
    CheckForQueuedHover();
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
}