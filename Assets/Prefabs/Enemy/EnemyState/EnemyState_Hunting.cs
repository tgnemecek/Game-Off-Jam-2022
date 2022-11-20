using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyState_Hunting : EnemyState
{
  Seeker _seeker;
  Vector3 _destination;
  bool _isApproaching = false;
  bool _hasCompletedPath = false;
  Path _path;
  int _currentWaypoint = 0;
  float _nextWaypointDistance = 3f;
  WaitForSeconds _recalculateInterval = new WaitForSeconds(0.5f);

  public EnemyState_Hunting(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    if (_seeker == null) _seeker = _context.Seeker;
    _isApproaching = false;
    _hasCompletedPath = false;
    _context.StartCoroutine(RecalculatePath(_context.Target.transform));
  }
  public override void UpdateState()
  {
    // Vector3 difference = _context.Target.transform.position - _context.transform.position;
    // if (difference.magnitude <= 1)
    // {
    //   SwitchState(_factory.Attacking());
    //   return;
    // }
  }

  IEnumerator RecalculatePath(Transform transform)
  {
    if (!_seeker.IsDone()) yield break;

    _isApproaching = true;

    while (_isApproaching)
    {
      StartPath(transform.position);
      yield return _recalculateInterval;
    }
  }

  void StartPath(Vector3 target)
  {
    _destination = target;
    _seeker.StartPath(_context.Rigidbody.position, target, (p) =>
    {
      if (!p.error)
      {
        _path = p;
        _path.Claim(this);
        _currentWaypoint = 0;
      }
    });
  }

  void ApproachUpdate()
  {
    if (_path == null) return;

    _hasCompletedPath = (_currentWaypoint >= _path.vectorPath.Count);

    if (_hasCompletedPath)
    {
      Debug.Log("Completed!");
      _isApproaching = false;
      // OnComplete?.Invoke();
      return;
    }

    Rigidbody rigidbody = _context.Rigidbody;

    Vector3 direction = (_path.vectorPath[_currentWaypoint] - rigidbody.position).normalized;

    // float accelerationMultiplier = GetReverseDirectionAcceleration(direction);
    float accelerationMultiplier = 1;

    Vector3 force = direction * _context.EnemyConfig.MovementSpeed * accelerationMultiplier * Time.deltaTime;

    Debug.Log($"force: {force}");
    rigidbody.AddForce(force);

    float distance = Vector3.Distance(rigidbody.position, _path.vectorPath[_currentWaypoint]);

    if (distance < _nextWaypointDistance)
    {
      _currentWaypoint++;
    }
    // _previousDirection = direction;
  }

  public override void FixedUpdateState()
  {
    float distanceFromTarget = Vector3.Distance(_context.Rigidbody.position, _context.Target.transform.position);

    if (distanceFromTarget <= _context.EnemyConfig.DecelerationDistanceFromTarget)
    {
      Debug.Log("Got Close!");
      return;
    }

    ApproachUpdate();



    // Vector3 target = new Vector3(
    //   _context.Target.transform.position.x,
    //   _context.transform.position.y,
    //   _context.Target.transform.position.z
    // );

    // Vector3 distance = target - _context.transform.position;
    // float distanceMag = distance.magnitude;
    // Vector3 direction = distance.normalized;
    // Vector3 velocity = (direction * _context.EnemyConfig.MovementSpeed);

    // float decelerationDistance = _context.EnemyConfig.DecelerationDistanceFromTarget;
    // float stopDistance = _context.EnemyConfig.StopDistanceFromTarget;

    // if (distanceMag < stopDistance)
    // {
    //   _context.Rigidbody.velocity = Vector3.zero;
    //   return;
    // }

    // if (distanceMag < decelerationDistance)
    // {
    //   float magFromStop = distanceMag - stopDistance;
    //   float decelerationDistanceFromStop = decelerationDistance - stopDistance;
    //   float multiplier = magFromStop / decelerationDistanceFromStop;

    //   velocity *= multiplier;

    //   if (multiplier < 0.1f)
    //   {
    //     velocity = Vector3.zero;
    //   }
    // }

    // _context.Rigidbody.velocity = velocity;
  }
  public override void ExitState() { }
  public override void EndOfTurn()
  {
    // Vector3 difference = _context.Target.transform.position - _context.transform.position;
    // difference.Normalize();
    // _context.transform.position += difference;
  }
}