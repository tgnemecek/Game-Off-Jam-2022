using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
  public EnemyState_Attacking(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() {
      Vector3 difference = _context.transform.position - _context.target.position;
      difference.Normalize();
      _context.target.position -= 3 * difference;
      SwitchState(_factory.Attacked());
   }
}