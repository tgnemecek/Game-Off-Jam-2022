using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardState
{
  protected Card _context;
  protected CardStateFactory _factory;

  public CardState(Card context, CardStateFactory factory)
  {
    _context = context;
    _factory = factory;
  }

  protected void SwitchState(CardState newState)
  {
    ExitState();
    _context.CurrentState = newState;
    newState.EnterState();
  }

  protected bool DetectDestroyed()
  {
    if (_context.HP <= 0)
    {
      SwitchState(_factory.Destroyed());
      return true;
    }
    return false;
  }

  protected void CheckCardSide(Camera camera)
  {
    float dot = Vector3.Dot(-_context.transform.forward, (camera.transform.position - _context.transform.position).normalized);

    bool facingCamera = dot > 0f;

    if (facingCamera)
    {
      _context.CardLayerController.ShowCardFront();
      return;
    }
    _context.CardLayerController.ShowCardBack();
  }


  public abstract void Draw();
  public abstract bool CanBeTargeted();
  public abstract void EnterState();
  public abstract void UpdateState();
  public abstract void FixedUpdateState();
  public abstract void ExitState();
}