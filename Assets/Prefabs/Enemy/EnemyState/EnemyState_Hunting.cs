using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Hunting : EnemyState
{
  public EnemyState_Hunting(Enemy context, EnemyStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState() {
    Vector3 difference = _context.target.position - _context.transform.position;
    if (difference.magnitude <= 1) 
    {
      SwitchState(_factory.Attacking());
      return;
    }
   }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override void EndOfTurn() {
    Vector3 difference = _context.target.position - _context.transform.position;
    difference.Normalize();
    _context.transform.position += difference;
  }
}