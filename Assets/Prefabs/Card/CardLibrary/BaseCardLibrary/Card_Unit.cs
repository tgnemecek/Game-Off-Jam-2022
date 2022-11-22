using UnityEngine;

public class Card_Unit : Card_Base
{
  public Card_Unit()
  {
    this.Type = CardTypes.Unit;
  }
  public override void Drag(Camera camera)
  {
    base.SnapToBoard(camera);
  }
  public override CardState OnConsume() => _stateFactory.InBoard();
}
