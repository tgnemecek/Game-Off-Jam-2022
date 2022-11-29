using UnityEngine;

public class Card_Resource : Card_Base
{
  public Card_Resource()
  {
    this.Type = CardTypes.Resource;
  }
  public override bool Drag(Camera camera)
  {
    return base.SnapToScreen(camera);
  }
  public override CardState OnConsume() => _stateFactory.Consumed();
}
