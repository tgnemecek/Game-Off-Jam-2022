using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_InPile : CardState
{
  public CardState_InPile(Card context, CardStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.transform.localScale = Vector3.one;
    _context.transform.rotation = Quaternion.Euler(-90, -180, 0);
    _context.CardLayerController.ShowCardBack();
    _context.CardLayerController.SetDrawPileLayer();
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