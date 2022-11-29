using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Dragged : CardState
{
  public CardState_Dragged(Card context, CardStateFactory factory) : base(context, factory) { }

  Camera _camera = Camera.main;
  Vector3 _lastValidPosition;
  bool _canClick = false;
  bool _clickQueued = false;

  public override void EnterState()
  {
    PlayerController.Instance.CardBeingDragged = _context;
    _canClick = false;
    _clickQueued = false;
    _context.CardLayerController.SetCloseUpLayer();
    _context.CardAudio.PlayCardClicked();
  }
  public override void UpdateState()
  {
    DetectClick();
  }

  public override void FixedUpdateState()
  {
    _canClick = _context.Drag(_camera);

    if (_canClick && _clickQueued)
    {
      _clickQueued = false;
      Click();
    }
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
      Click();
    }
  }

  void Click()
  {
    if (PlayerController.Instance.IsHoveringOnHand && !_context.WasPlayed)
    {
      SwitchState(_factory.InHand());
      return;
    }
    if (_context.WasPlayed)
    {
      SwitchState(_factory.InBoard());
      return;
    }
    if (!_canClick)
    {
      _clickQueued = true;
      return;
    }
    if (ResourcesManager.Instance.TryConsume(_context.ResourcesCostDictionary))
    {
      SwitchState(_context.OnConsume());
    }
  }

  public override void ExitState()
  {
    PlayerController.Instance.CardBeingDragged = null;
  }
}