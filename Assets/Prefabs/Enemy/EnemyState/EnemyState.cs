using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
  protected Enemy _context;
  protected EnemyStateFactory _factory;

  public EnemyState(Enemy context, EnemyStateFactory factory)
  {
    _context = context;
    _factory = factory;
  }

  protected void SwitchState(EnemyState newState)
  {
    ExitState();
    newState.EnterState();
    _context.CurrentState = newState;
  }


  public abstract void EnterState();
  public abstract void UpdateState();
  public abstract void FixedUpdateState();
  public abstract void ExitState();
  public abstract void EndOfTurn();
}