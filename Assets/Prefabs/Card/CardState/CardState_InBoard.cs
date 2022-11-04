using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InBoard : CardState
{
  public CardState_InBoard(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void OnMouseEnter() { }
  public override void OnMouseExit() { }
  public override void ExitState() { }
}