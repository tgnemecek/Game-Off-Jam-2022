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
    LeanTween.rotateAround(_context.gameObject, Vector3.up, 360 * 5, _context.CardConfig.DeathDuration).setEaseOutCirc();
    LeanTween.scale(_context.gameObject, Vector3.zero, _context.CardConfig.DeathDuration);

    yield break;
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
}