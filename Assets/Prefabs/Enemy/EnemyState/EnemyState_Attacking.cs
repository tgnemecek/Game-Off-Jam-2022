using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
  public EnemyState_Attacking(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    if (_context.Target.isDead()) {
      SwitchState(_factory.Hunting());
      return;
    }

    _context.Rigidbody.velocity = Vector3.zero;

    LeanTween
      .rotateY(_context.gameObject, 0f, 1f / _context.EnemyConfig.WalkRotationSpeed)
      .setOnComplete(Attack);
  }

  void Attack()
  {
    var target = _context.Target.GetTransform().position;
    var startPos = _context.transform.position;
    var seq = LeanTween.sequence();

    seq.append(LeanTween.move(_context.gameObject, target, 0.5f / _context.EnemyConfig.AttackSpeed).setEaseInBack());
    seq.append(LeanTween.move(_context.gameObject, startPos, 0.5f / _context.EnemyConfig.AttackSpeed).setEaseOutExpo()
      .setOnComplete(OnAttackLanded));
  }


  void OnAttackLanded()
  {
    _context.Target.ReceiveDamage(_context.Damage);
    SwitchState(_factory.InBattle());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}