public class Card_Resource : Card
{
  public Card_Resource(string name, int woodCost, int stoneCost) : base(CardTypes.Resource, name, woodCost, stoneCost) { }

  public override void Play()
  {
    ResourcesManager.Instance.Gain(Resource.Wood, 1);
  }

  public override void EndOfTurn()
  {
    // noop
  }
}
