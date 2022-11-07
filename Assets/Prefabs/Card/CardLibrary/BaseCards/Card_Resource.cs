public class Card_Resource : Card_Base
{
  public Card_Resource(
    int id,
    string name,
    string description,
    string image,
    int woodCost,
    int stoneCost
  ) : base(
    id,
    CardTypes.Resource,
    name,
    description,
    image,
    woodCost,
    stoneCost
  )
  { }

  public override void Play()
  {
    ResourcesManager.Instance.Gain(Resource.Wood, 1);
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
