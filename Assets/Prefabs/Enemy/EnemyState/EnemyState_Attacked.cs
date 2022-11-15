using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacked : EnemyState
{
  public EnemyState_Attacked(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() {
    SwitchState(_factory.Hunting());
  }
}