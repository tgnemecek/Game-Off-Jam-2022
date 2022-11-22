using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Consumed : CardState
{
  Camera _camera = Camera.main;
  float _startTime;

  public CardState_Consumed(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    GameManager.Instance.Hand.RemoveCard(_context);
    _context.Play();

    var duration = _context.CardConfig.ConsumeAnimationTime;
    var rotation = _context.CardConfig.ConsumeAnimationRotation;

    Vector3 smallestSize = new Vector3(
      0.01f,
      0.01f,
      0.01f
    );

    LeanTween.rotateAroundLocal(_context.gameObject, Vector3.up, rotation, duration);
    LeanTween.scale(_context.gameObject, smallestSize, duration)
      .setEaseInSine()
      .setOnComplete(() =>
      {
        GameManager.Instance.DiscardPile.Discard(_context);
        SwitchState(_factory.NotInPlay());
      });
  }

  public override void UpdateState()
  {
    base.CheckCardSide(_camera);
  }
  public override void FixedUpdateState() { }
  public override void ExitState() { }
}