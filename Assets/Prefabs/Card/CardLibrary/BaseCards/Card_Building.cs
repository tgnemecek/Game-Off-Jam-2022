public class Card_Building : Card
{
  public Card_Building(string name, int woodCost, int stoneCost) : base(CardTypes.Building, name, woodCost, stoneCost) { }

  public override void Play()
  {
    // noop
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
