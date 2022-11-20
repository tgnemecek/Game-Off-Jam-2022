using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Dead : EnemyState
{
  public EnemyState_Dead(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    // @TODO: Death animation
    GameManager.Instance.EnemyManager.RegisterEnemyDeath(_context);
  }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() { }
}