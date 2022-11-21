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
    _context.CurrentState = newState;
    newState.EnterState();
  }

  public abstract void EnterState();
  public abstract void UpdateState();
  public abstract void FixedUpdateState();
  public abstract void ExitState();
  public abstract void EndOfTurn();
}