using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState_Consumed : CardState
{
  Camera _camera = Camera.main;

  public CardState_Consumed(Card context, CardStateFactory factory) : base(context, factory) { }

  public override void EnterState()
  {
    // _context.StartCoroutine(Rotation());
    // var time = _context.CardConfig.ConsumeAnimationTime;


    // LeanTween.rotateAroundLocal(_context.gameObject, Vector3.up, rotation, time);
  }

  public override void UpdateState()
  {
    base.CheckCardSide(_camera);
  }
  public override void FixedUpdateState()
  {
    var amount = _context.CardConfig.ConsumeAnimationRotation + _context.transform.rotation.eulerAngles.y;
    _context.transform.rotation = Quaternion.Euler(_context.transform.rotation.x, amount, _context.transform.rotation.z);
  }
  public override void ExitState() { }
}