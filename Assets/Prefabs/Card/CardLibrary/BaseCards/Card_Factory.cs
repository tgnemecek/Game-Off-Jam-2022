public class Card_Factory : Card
{
  public Card_Factory(string name, int woodCost, int stoneCost) : base(CardTypes.Factory, name, woodCost, stoneCost) { }

  public override void Play()
  {
    // noop
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
