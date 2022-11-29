using UnityEngine;

public class Card_Item : Card_Base
{
  public Card_Item()
  {
    this.Type = CardTypes.Item;
  }
  public override bool Drag(Camera camera)
  {
    return base.SnapToScreen(camera);
  }
  public override CardState OnConsume() => _stateFactory.Consumed();
}
