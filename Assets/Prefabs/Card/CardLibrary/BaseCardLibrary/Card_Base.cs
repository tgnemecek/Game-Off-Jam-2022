using System.Collections;
using UnityEngine;

public class Card_Base : Card
{
  public override void Play()
  {
    // noop
  }

  public override bool Drag(Camera camera) => false;
  public override CardState OnConsume() => _stateFactory.NotInPlay();
}
