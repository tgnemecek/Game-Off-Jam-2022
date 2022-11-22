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
    _context.Drag(_camera);
    SaveLastValidPosition();
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
        SwitchState(_context.OnConsume());
      }
    }
  }

  public override void ExitState()
  {
    PlayerController.Instance.CardBeingDragged = null;
  }
}