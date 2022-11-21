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
  readonly float _nextWaypointDistance = 3f;
  readonly WaitForSeconds _recalculateInterval = new WaitForSeconds(0.5f);
  Coroutine _recalculateCoroutine;
  Coroutine _walkCoroutine;

  public EnemyState_Hunting(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    if (_seeker == null) _seeker = _context.Seeker;
    _isApproaching = false;
    _hasCompletedPath = false;
    _currentWaypoint = 0;
    _walkCoroutine = _context.StartCoroutine(WalkAnimation());
    SetTarget(_context.Target);
  }
  public override void UpdateState()
  {
    DetectBattleStart();
    DetectCardsToBattleWith();
  }
  public override void FixedUpdateState()
  {
    ApproachUpdate();
  }

  void DetectCardsToBattleWith()
  {
    if (_context.Target.GetTransform() != _context.Core.transform) return;
    if (_context.CardProximityDetector.IsCloseToAnotherCard())
    {
      Collider newTarget = _context.CardProximityDetector.GetClosestCollider();
      IHitable hitable;

      if (newTarget.gameObject.TryGetComponent<IHitable>(out hitable))
      {
        SetTarget(hitable);
      }
    }
  }

  void DetectBattleStart()
  {
    Vector3 closestPoint = _context.Target.GetCollider().ClosestPointOnBounds(_context.transform.position);

    float distance = (_context.transform.position - closestPoint).magnitude;
    float theshold = _context.EnemyConfig.StopDistanceFromTarget;

    if (distance <= theshold)
    {
      SwitchState(_factory.InBattle());
    }
  }


  void SetTarget(IHitable hitable)
  {
    CancelCurrentPath();

    _context.Target = hitable;
    _recalculateCoroutine = _context.StartCoroutine(RecalculatePath(hitable.GetTransform()));
  }

  IEnumerator WalkAnimation()
  {
    bool isTurningToPositive = true;

    while (true)
    {
      float rotationAmount = _context.EnemyConfig.WalkRotationAmount * (isTurningToPositive ? 1 : -1);
      float time = 1f / _context.EnemyConfig.WalkRotationSpeed;

      isTurningToPositive = !isTurningToPositive;

      bool hasCompleted = false;

      LeanTween
        .rotateY(_context.gameObject, rotationAmount, time)
        .setOnComplete(() => hasCompleted = true);

      yield return new WaitUntil(() => hasCompleted);
    }
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

  void CancelCurrentPath()
  {
    if (_recalculateCoroutine != null) _context.StopCoroutine(_recalculateCoroutine);
    _seeker.CancelCurrentPathRequest();
  }

  void ApproachUpdate()
  {
    if (_path == null) return;

    _hasCompletedPath = (_currentWaypoint >= _path.vectorPath.Count);

    if (_hasCompletedPath)
    {
      _isApproaching = false;
      return;
    }

    Rigidbody rigidbody = _context.Rigidbody;

    Vector3 direction = (_path.vectorPath[_currentWaypoint] - rigidbody.position).normalized;

    Vector3 velocity = direction * _context.EnemyConfig.MovementSpeed * Time.deltaTime;

    rigidbody.velocity = velocity;

    float distance = Vector3.Distance(rigidbody.position, _path.vectorPath[_currentWaypoint]);

    if (distance < _nextWaypointDistance)
    {
      _currentWaypoint++;
    }
  }

  public override void ExitState()
  {
    CancelCurrentPath();
    if (_walkCoroutine != null) _context.StopCoroutine(_walkCoroutine);
  }
  public override void EndOfTurn() { }
}