using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_NotInPlay : EnemyState
{
  public EnemyState_NotInPlay(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState()
  {
    if (_context.Target != null)
    {
      SwitchState(_factory.Hunting());
      return;
    }
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}