public class Card_Spell : Card
{
  public Card_Spell(string name, int woodCost, int stoneCost) : base(CardTypes.Spell, name, woodCost, stoneCost) { }

  public override void Play()
  {
    // noop
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
