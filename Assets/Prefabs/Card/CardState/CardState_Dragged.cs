using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Dragged : CardState
{
  public CardState_Dragged(Card context, CardStateFactory factory) : base(context, factory) { }

  Camera _camera = Camera.main;
  Vector3 _lastValidPosition;

  public override void EnterState()
  {
    PlayerController.Instance.CardBeingDragged = _context;
    _context.CardLayerController.SetDraggedLayer();
  }
  public override void UpdateState()
  {
    DetectClick();
  }

  public override void FixedUpdateState()
  {
    SnapToBoard();
    SaveLastValidPosition();
  }

  void SnapToBoard()
  {
    (Vector3, Quaternion) GetTarget()
    {
      if (PlayerController.Instance.IsHoveringOnHand && _context.CanReturnToHand)
      {
        float targetX = _camera.transform.rotation.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(targetX, 0, 0);

        Vector3 screenPos = new Vector3(
          Input.mousePosition.x,
          Input.mousePosition.y,
          _camera.WorldToScreenPoint(_context.PositionInHand).z
        );

        Vector3 worldPos = _camera.ScreenToWorldPoint(screenPos);

        return (worldPos, rotation);
      }
      Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
      RaycastHit hitInfo;
      if (Physics.Raycast(ray, out hitInfo, 9999, GameManager.Instance.GameConfig.BoardLayerMask))
      {
        return (hitInfo.point, hitInfo.collider.transform.rotation);
      }
      return (_context.transform.position, _context.transform.rotation);
    }

    var (target, rotation) = GetTarget();

    _context.transform.position = Vector3.Lerp(
      _context.transform.position,
      target,
      _context.CardConfig.CatchUpSpeedWhileDragging
    );
    _context.transform.rotation = Quaternion.Lerp(
      _context.transform.rotation,
      rotation,
      _context.CardConfig.CatchUpSpeedWhileDragging
    );
  }

  void SaveLastValidPosition()
  {
    if (PlayerController.Instance.IsHoveringOnHand) return;
    if (_context.CardProximityDetector.IsCloseToAnotherCard()) return;
    _context.LastValidBoardPosition = _context.transform.position;
  }

  void DetectClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      if (PlayerController.Instance.IsHoveringOnHand && _context.CanReturnToHand)
      {
        SwitchState(_factory.InHand());
        return;
      }
      if (ResourcesManager.Instance.TryConsume(_context.Cost))
      {
        SwitchState(_factory.InBoard());
      }
    }
  }

  public override void ExitState()
  {
    PlayerController.Instance.CardBeingDragged = null;
  }
}