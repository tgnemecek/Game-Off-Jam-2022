using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Dragged : CardState
{
  public CardState_Dragged(Card context, CardStateFactory factory) : base(context, factory) { }

  Camera _camera;
  Vector3 _mousePositionOffset;

  public override void EnterState()
  {
    // @TODO Replace Camera.main
    if (_camera == null) _camera = Camera.main;
    Vector3 mouseWorldPosition = GetMouseWorldPosition();
    _mousePositionOffset = _context.transform.position - mouseWorldPosition;
  }
  public override void UpdateState()
  {
    UpdatePosition();
    BendCard();
    DetectClick();
  }

  void UpdatePosition()
  {
    Vector3 sumOfPositions = GetMouseWorldPosition() + _mousePositionOffset;
    Vector3 newPosition = new Vector3(
      sumOfPositions.x,
      sumOfPositions.y,
      _context.transform.position.z
    );
    LeanTween.move(
      _context.gameObject,
      newPosition,
      _context.CardConfig.CatchUpTimeWhileDragging
    );
  }

  void BendCard()
  {
    float x = Input.GetAxis("Mouse X");
    float currentY = _context.transform.rotation.eulerAngles.y;

    var _cardBendSpeed = _context.CardConfig.CardBendSpeed;
    var _cardBendMaxRotation = _context.CardConfig.CardBendMaxRotation;
    var _cardBendSmoothness = _context.CardConfig.CardBendSmoothness;

    float amountMultiplied = x * _cardBendSpeed;
    float amountLerped = Mathf.Lerp(currentY, currentY + amountMultiplied, 1 / _cardBendSmoothness);
    float amountClamped = Mathf.Clamp(amountLerped, -_cardBendMaxRotation, _cardBendMaxRotation);

    _context.transform.rotation = Quaternion.Euler(0f, amountClamped, 0f);

    // LeanTween.rotateY(
    //   _context.gameObject,
    //   amountClamped,
    //   _context.CardConfig.CatchUpTimeWhileDragging
    // ).setEaseInOutCubic().setDelay(_cardBendSmoothness);

    // _context.transform.rotation = Quaternion.Euler(0f, amountClamped, 0f);
  }

  Vector3 GetMouseWorldPosition() => _camera.ScreenToWorldPoint(Input.mousePosition);

  void DetectClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      if (PlayerController.Instance.IsHoveringOnLowerSection)
      {
        SwitchState(_factory.InHand());
        return;
      }
      SwitchState(_factory.InBoard());
    }
  }

  public override void FixedUpdateState() { }
  public override void OnMouseEnter() { }
  public override void OnMouseExit() { }
  public override void ExitState() { }
}