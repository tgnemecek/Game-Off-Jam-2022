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
    newState.EnterState();
    _context.CurrentState = newState;
  }


  public abstract void EnterState();
  public abstract void UpdateState();
  public abstract void FixedUpdateState();
  public abstract void ExitState();
}