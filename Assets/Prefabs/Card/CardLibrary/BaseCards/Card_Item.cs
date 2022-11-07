public class Card_Item : Card_Base
{
  public Card_Item(
    int id,
    string name,
    string description,
    string image,
    int woodCost,
    int stoneCost
  ) : base(
    id,
    CardTypes.Item,
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
