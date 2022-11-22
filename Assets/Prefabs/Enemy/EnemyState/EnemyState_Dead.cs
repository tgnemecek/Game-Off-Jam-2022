using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Dead : EnemyState
{
  public EnemyState_Dead(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    LeanTween.rotateAround(_context.gameObject, Vector3.up, 360 * 5, _context.EnemyConfig.DeathDuration).setEaseOutCirc();
    LeanTween.scale(_context.gameObject, Vector3.zero, _context.EnemyConfig.DeathDuration)
      .setOnComplete(RegisterDeath);
  }

  void RegisterDeath()
  {
    GameManager.Instance.EnemyManager.RegisterEnemyDeath(_context);
    _context.gameObject.SetActive(false);
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}