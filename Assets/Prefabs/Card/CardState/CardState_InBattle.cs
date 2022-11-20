using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBattle : CardState
{
  public CardState_InBattle(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }

  public override void UpdateState()
  {
    if (DetectDestroyed()) return;
    if (DetectBattleEnd()) return;
  }

  bool DetectBattleEnd()
  {
    if (_context.BattlingAgainst.Count == 0)
    {
      SwitchState(_factory.InBoard());
      return true;
    }
    return false;
  }

  public override void FixedUpdateState() { }
  public override void ExitState() { }
}