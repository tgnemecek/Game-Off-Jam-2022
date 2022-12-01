using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Destroyed : CardState
{
  public CardState_Destroyed(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    Vector3 originalScale = _context.transform.localScale;
    _context.GetCollider().enabled = false;

    LeanTween.rotateAround(_context.gameObject, Vector3.up, 360 * 5, _context.CardConfig.DeathDuration).setEaseOutCirc();
    LeanTween.scale(_context.gameObject, Vector3.zero, _context.CardConfig.DeathDuration)
      .setOnComplete(() =>
      {
        _context.transform.localScale = originalScale;
        GameManager.Instance.DiscardPile.Discard(_context);
      });
  }

  public override void AddToPile(IPile pile)
  {
    SwitchState(_factory.InPile());
  }
  public override void Draw() { }
  public override bool CanBeTargeted() => false;
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void ExitState()
  {
    _context.GetCollider().enabled = true;
  }
}