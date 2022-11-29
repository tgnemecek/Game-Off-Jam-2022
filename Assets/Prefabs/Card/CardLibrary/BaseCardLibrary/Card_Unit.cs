using UnityEngine;

public class Card_Unit : Card_Base
{
  public Card_Unit()
  {
    this.Type = CardTypes.Unit;
  }
  public override bool Drag(Camera camera)
  {
    return base.SnapToBoard(camera);
  }
  public override CardState OnConsume() => _stateFactory.InBoard();
}
