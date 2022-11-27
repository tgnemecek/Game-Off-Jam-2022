using System.Collections;
using UnityEngine;

public class Card_Base : Card
{
  public override void Play()
  {
    // noop
  }

  public override void Drag(Camera camera) { }
  public override CardState OnConsume() => _stateFactory.NotInPlay();
}
