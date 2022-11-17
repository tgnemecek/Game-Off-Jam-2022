using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Hunting : EnemyState
{
  public EnemyState_Hunting(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState()
  {
    Vector3 difference = _context.Target.transform.position - _context.transform.position;
    if (difference.magnitude <= 1)
    {
      SwitchState(_factory.Attacking());
      return;
    }
  }
  public override void FixedUpdateState()
  {
    Vector3 target = new Vector3(
      _context.Target.transform.position.x,
      _context.transform.position.y,
      _context.Target.transform.position.z
    );

    Vector3 distance = target - _context.transform.position;
    float distanceMag = distance.magnitude;
    Vector3 direction = distance.normalized;
    Vector3 velocity = (direction * _context.EnemyConfig.MovementSpeed);

    float decelerationDistance = _context.EnemyConfig.DecelerationDistanceFromTarget;
    float stopDistance = _context.EnemyConfig.StopDistanceFromTarget;

    if (distanceMag < stopDistance)
    {
      _context.Rigidbody.velocity = Vector3.zero;
      return;
    }

    if (distanceMag < decelerationDistance)
    {
      float magFromStop = distanceMag - stopDistance;
      float decelerationDistanceFromStop = decelerationDistance - stopDistance;
      float multiplier = magFromStop / decelerationDistanceFromStop;

      velocity *= multiplier;

      if (multiplier < 0.1f)
      {
        velocity = Vector3.zero;
      }
    }

    _context.Rigidbody.velocity = velocity;
  }
  public override void ExitState() { }
  public override void EndOfTurn()
  {
    Vector3 difference = _context.Target.transform.position - _context.transform.position;
    difference.Normalize();
    _context.transform.position += difference;
  }
}