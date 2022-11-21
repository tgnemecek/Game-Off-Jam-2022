using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
  public EnemyState_Attacking(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.StartCoroutine(AttackAnimation());
  }

  IEnumerator AttackAnimation()
  {
    yield return new WaitForSeconds(.5f);
    // @TODO: Animation here
    SwitchState(_factory.InBattle());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}