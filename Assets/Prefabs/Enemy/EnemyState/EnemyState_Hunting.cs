using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Hunting : EnemyState
{
  public EnemyState_Hunting(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState()
  {
    Vector3 difference = _context.Target.position - _context.transform.position;
    if (difference.magnitude <= 1)
    {
      SwitchState(_factory.Attacking());
      return;
    }
  }
  public override void FixedUpdateState()
  {
    Vector3 target = new Vector3(
      _context.Target.position.x,
      _context.Target.position.y,
      _context.transform.position.z
    );

    Vector3 distance = target - _context.transform.position;
    Vector3 direction = distance.normalized;
    Vector3 force = (direction * _context.EnemyConfig.MovementSpeed) / distance.sqrMagnitude;

    _context.Rigidbody.AddForce(force);
  }
  public override void ExitState() { }
  public override void EndOfTurn()
  {
    Vector3 difference = _context.Target.position - _context.transform.position;
    difference.Normalize();
    _context.transform.position += difference;
  }
}