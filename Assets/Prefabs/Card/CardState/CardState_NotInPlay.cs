using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_NotInPlay : CardState
{
  public CardState_NotInPlay(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState() { }
  public override void AddToPile(IPile pile) { }
  public override void Draw() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override bool CanBeTargeted() => false;
}