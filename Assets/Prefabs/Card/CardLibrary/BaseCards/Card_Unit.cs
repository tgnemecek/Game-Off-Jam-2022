public class Card_Unit : Card_Base
{
  public Card_Unit(
    int id,
    string name,
    string description,
    string image,
    int woodCost,
    int stoneCost
  ) : base(
    id,
    CardTypes.Unit,
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
