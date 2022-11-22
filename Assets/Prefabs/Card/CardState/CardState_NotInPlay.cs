using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_NotInPlay : CardState
{
  public CardState_NotInPlay(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    if (_context.CardInitializer == CardInitializer.BoosterPack)
    {
      SwitchState(_factory.InBooster());
    }
    else
    {
      SwitchState(_factory.InPile());
    }
  }
  public override void UpdateState()
  {
    if (_context.DrawnOnThisFrame)
    {
      SwitchState(_factory.InHand());
      return;
    }
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
}