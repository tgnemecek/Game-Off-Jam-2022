using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Destroyed : CardState
{
  public CardState_Destroyed(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    _context.HP = 0;
    _context.StartCoroutine(DestroyedAnimation());
  }

  IEnumerator DestroyedAnimation()
  {
    yield break;
    // @TODO: Add animation here
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
}