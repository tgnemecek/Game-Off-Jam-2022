public class Card_Base : Card
{
  public Card_Base(
    int id,
    CardTypes type,
    string name,
    string description,
    string image,
    int woodCost,
    int stoneCost
  ) : base(
    id,
    type,
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