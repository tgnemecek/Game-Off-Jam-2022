using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_NotInPlay : CardState
{
  public CardState_NotInPlay(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState()
  {
    if (_context.DrawnOnThisFrame)
    {
      SwitchState(_factory.InHand());
      return;
    }
  }
  public override void FixedUpdateState() { }
  public override void OnMouseEnter() { }
  public override void OnMouseExit() { }
  public override void ExitState() { }
}