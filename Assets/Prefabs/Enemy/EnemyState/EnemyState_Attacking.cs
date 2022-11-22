using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
  public EnemyState_Attacking(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.Rigidbody.velocity = Vector3.zero;

    LeanTween
      .rotateY(_context.gameObject, 0f, 1f / _context.EnemyConfig.WalkRotationSpeed)
      .setOnComplete(Attack);
  }

  void Attack()
  {
    var target = _context.Target.GetTransform().position;

    LeanTween.move(_context.gameObject, target, 1f / _context.EnemyConfig.AttackSpeed).setEaseInElastic();
    LeanTween.scale(_context.gameObject, Vector3.zero, 1f / _context.EnemyConfig.AttackSpeed).setEaseInElastic()
      .setOnComplete(OnAttackLanded);
  }

  void OnAttackLanded()
  {
    _context.Target.ReceiveDamage(_context.Damage);
    SwitchState(_factory.Dead());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}