using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Dying : EnemyState
{
  public EnemyState_Dying(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}