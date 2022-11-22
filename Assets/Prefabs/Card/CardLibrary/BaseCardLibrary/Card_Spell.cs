using UnityEngine;

public class Card_Spell : Card_Base
{
  public Card_Spell()
  {
    this.Type = CardTypes.Spell;
  }
  public override void Drag(Camera camera)
  {
    base.SnapToScreen(camera);
  }
  public override CardState OnConsume() => _stateFactory.Consumed();
}
