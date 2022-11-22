using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attacked : EnemyState
{
  public EnemyState_Attacked(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.StartCoroutine(AttackedAnimation());
  }

  IEnumerator AttackedAnimation()
  {
    float time = 1f / _context.EnemyConfig.AttackSpeed;
    Vector3 scaleVector = Vector3.one * _context.EnemyConfig.AttackedShrinkScale;

    LTSeq rotateSequence = LeanTween.sequence();

    rotateSequence.append(LeanTween.rotateY(_context.gameObject, -1f * _context.EnemyConfig.AttackedRotationMultiplier, time / 2f));
    rotateSequence.append(LeanTween.rotateY(_context.gameObject, 2f * _context.EnemyConfig.AttackedRotationMultiplier, time / 2f));
    rotateSequence.append(LeanTween.rotateY(_context.gameObject, -1.5f * _context.EnemyConfig.AttackedRotationMultiplier, time / 2f));
    rotateSequence.append(LeanTween.rotateY(_context.gameObject, 0.5f * _context.EnemyConfig.AttackedRotationMultiplier, time / 2f));

    LeanTween.scale(_context.gameObject, scaleVector, time).setOnComplete(() => LeanTween.scale(_context.gameObject, Vector3.one, time));
    
    yield return new WaitForSeconds(time);
    SwitchState(_factory.InBattle());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() {
    SwitchState(_factory.Hunting());
  }
}