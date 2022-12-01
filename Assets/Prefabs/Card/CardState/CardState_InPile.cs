using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InPile : CardState
{
  public CardState_InPile(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    _context.transform.localPosition = Vector3.zero;
    _context.transform.localScale = Vector3.one;
    _context.transform.rotation = Quaternion.Euler(-90, -180, 0);
    _context.CardLayerController.SetPileLayer();
    _context.Heal(9999);
    _context.WasPlayed = false;
  }
  public override void UpdateState() { }
  public override void Draw()
  {
    SwitchState(_factory.InHand());
  }
  public override void AddToPile(IPile pile)
  {
    EnterState();
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
  public override bool CanBeTargeted() => false;
}