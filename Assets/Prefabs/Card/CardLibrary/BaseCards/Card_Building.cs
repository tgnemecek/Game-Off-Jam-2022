public class Card_Building : Card_Base
{
  public Card_Building(
    int id,
    string name,
    string description,
    string image,
    int woodCost,
    int stoneCost
  ) : base(
    id,
    CardTypes.Building,
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
