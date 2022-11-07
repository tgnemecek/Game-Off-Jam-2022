public class Card_Spell : Card_Base
{
  public Card_Spell(int id,
    string name,
    string description,
    string image,
    int woodCost,
    int stoneCost
  ) : base(
    id,
    CardTypes.Spell,
    name,
    description,
    image,
    woodCost,
    stoneCost
  )
  { }

  public override void Play()
  {
    // noop
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
