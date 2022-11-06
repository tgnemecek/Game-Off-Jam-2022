public class Card_Unit : Card
{
  public Card_Unit(string name, int woodCost, int stoneCost) : base(CardTypes.Unit, name, woodCost, stoneCost) { }

  public override void Play()
  {
    // noop
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
