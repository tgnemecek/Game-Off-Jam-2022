using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacking : EnemyState
{
  public EnemyState_Attacking(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    if (_context.Target.isDead())
    {
      SwitchState(_factory.Hunting());
      return;
    }

    _context.Rigidbody.velocity = Vector3.zero;
    _context.EnemyAudio.PlayAttack();

    LeanTween
      .rotateY(_context.gameObject, 0f, 1f / _context.EnemyConfig.WalkRotationSpeed)
      .setOnComplete(Attack);
  }

  void Attack()
  {
    var targetPos = _context.Target.GetTransform().position;
    var target = new Vector3(
      targetPos.x,
      _context.transform.position.y,
      targetPos.z
    );
    var startPos = _context.transform.position;
    var seq = LeanTween.sequence();

    seq.append(LeanTween.move(_context.gameObject, target, 0.5f / _context.EnemyConfig.AttackSpeed).setEaseInBack().setOnComplete(OnAttackLanded));
    seq.append(LeanTween.move(_context.gameObject, startPos, 0.5f / _context.EnemyConfig.AttackSpeed).setEaseOutExpo());
  }

  void OnAttackLanded()
  {
    _context.Target.ReceiveDamage(_context.Damage);
    SwitchState(_factory.Attacked());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}