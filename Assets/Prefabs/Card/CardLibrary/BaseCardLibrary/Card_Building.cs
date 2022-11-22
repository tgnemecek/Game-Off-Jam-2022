using UnityEngine;

public class Card_Building : Card_Base
{
  public Card_Building()
  {
    this.Type = CardTypes.Building;
  }
  public override void Drag(Camera camera)
  {
    base.SnapToBoard(camera);
  }
  public override CardState OnConsume() => _stateFactory.InBoard();
}
