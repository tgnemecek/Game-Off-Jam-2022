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
    PlayerController.Instance.IsDraggingCard = true;
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
    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;


    if (Physics.Raycast(ray, out hitInfo, 9999, _context.CardConfig.BoardLayerMask))
    {
      Vector3 point = hitInfo.point;

      _context.transform.position = Vector3.Lerp(
        _context.transform.position,
        point,
        _context.CardConfig.CatchUpSpeedWhileDragging
      );
      _context.transform.rotation = Quaternion.Lerp(
        _context.transform.rotation,
        hitInfo.collider.transform.rotation,
        _context.CardConfig.CatchUpSpeedWhileDragging
      );
    }
  }

  void SaveLastValidPosition()
  {
    if (PlayerController.Instance.IsHoveringOnLowerSection) return;
    if (_context.CardProximityDetector.IsCloseToAnotherCard()) return;
    _context.LastValidBoardPosition = _context.transform.position;
  }

  void DetectClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      if (PlayerController.Instance.IsHoveringOnLowerSection && _context.CanReturnToHand)
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

  public override void OnMouseEnter() { }
  public override void OnMouseExit() { }
  public override void ExitState()
  {
    PlayerController.Instance.IsDraggingCard = false;
  }
}