#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Card_Wood : Card_Resource
{
  public Card_Wood()
  {
    this.Id = 1;
    this.Name = "Wood";
    this.Description = "";
    this.Image = "Card/Resource/Wood";
    this.WoodCost = 0;
    this.FishCost = 0;
    this.GoldCost = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(1, ResourceTypes.Wood);
  }

  public override void EndOfTurn()
  {
    // TODO: Add logic
  }
}