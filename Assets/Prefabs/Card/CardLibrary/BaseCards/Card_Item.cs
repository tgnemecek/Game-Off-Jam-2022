public class Card_Item : Card
{
  public Card_Item(string name, int woodCost, int stoneCost) : base(CardTypes.Item, name, woodCost, stoneCost) { }

  public override void Play()
  {
    // noop
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
