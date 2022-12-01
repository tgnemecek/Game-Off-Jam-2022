using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_NotInPlay : CardState
{
  public CardState_NotInPlay(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState()
  {
    if (_context.CardInitializer == CardInitializer.BoosterPack)
    {
      SwitchState(_factory.InBooster());
    }
    else if (_context.CardInitializer == CardInitializer.Pile)
    {
      SwitchState(_factory.InPile());
    }
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override bool CanBeTargeted() => false;
}