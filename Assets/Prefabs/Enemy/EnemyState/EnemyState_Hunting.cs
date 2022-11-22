using System.Collections;
using UnityEngine;

public class EnemyState_Hunting : EnemyState
{
  Vector3 _destination;
  Coroutine _walkCoroutine;

  public EnemyState_Hunting(Enemy context, EnemyStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    _walkCoroutine = _context.StartCoroutine(WalkAnimation());
    _context.NavMeshAgent.enabled = true;
    SetTarget(_context.Target);
  }
  public override void UpdateState()
  {
    _destination = _context.Target.GetCollider().ClosestPointOnBounds(_context.transform.position);

    DetectBattleStart();
    DetectCardsToBattleWith();
  }
  public override void FixedUpdateState()
  {
    _context.NavMeshAgent.SetDestination(_destination);
  }

  void DetectCardsToBattleWith()
  {
    if (_context.Target.GetTransform() != GameManager.Instance.Core.transform) return;
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
    float distance = (_context.transform.position - _destination).magnitude;
    float theshold = _context.EnemyConfig.StopDistanceFromTarget;

    if (distance <= theshold)
    {
      SwitchState(_factory.Attacking());
    }
  }


  void SetTarget(IHitable hitable)
  {
    _context.Target = hitable;
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

  public override void ExitState()
  {
    if (_walkCoroutine != null) _context.StopCoroutine(_walkCoroutine);
    _context.NavMeshAgent.isStopped = true;
    _context.NavMeshAgent.enabled = false;
  }
  public override void EndOfTurn() { }
}