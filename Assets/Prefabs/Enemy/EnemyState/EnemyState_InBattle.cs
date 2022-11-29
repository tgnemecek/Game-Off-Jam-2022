using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_InBattle : EnemyState
{
  public EnemyState_InBattle(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.Rigidbody.velocity = Vector3.zero;

    if (_context.Target.isDead()) {
      SwitchState(_factory.Hunting());
    } else {
      LeanTween
      .rotateY(_context.gameObject, 0f, 1f / _context.EnemyConfig.WalkRotationSpeed)
      .setOnComplete(() => _context.StartCoroutine(AttackSpeedTimer()));
    }
  }

  IEnumerator AttackSpeedTimer()
  {
    float time = 1f / _context.EnemyConfig.AttackSpeed;
    yield return new WaitForSeconds(time);

    SwitchState(_factory.Attacking());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}