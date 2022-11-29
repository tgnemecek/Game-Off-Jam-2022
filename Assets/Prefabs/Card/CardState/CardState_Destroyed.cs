using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Destroyed : CardState
{
  public CardState_Destroyed(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    _context.HP = 0;
    Vector3 originalScale = _context.transform.localScale;

    LeanTween.rotateAround(_context.gameObject, Vector3.up, 360 * 5, _context.CardConfig.DeathDuration).setEaseOutCirc();
    LeanTween.scale(_context.gameObject, Vector3.zero, _context.CardConfig.DeathDuration)
      .setOnComplete(() =>
      {
        _context.gameObject.SetActive(false);
        _context.transform.localScale = originalScale;
      });
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState()
  {
    _context.gameObject.SetActive(true);
  }
}