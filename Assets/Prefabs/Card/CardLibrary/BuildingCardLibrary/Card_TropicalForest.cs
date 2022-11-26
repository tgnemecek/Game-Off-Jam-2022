#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Card_TropicalForest : Card_Building
{
  public Card_TropicalForest()
  {
    this.Id = 21;
    this.Name = "Tropical Forest";
    this.Description = "Gain 3 Wood at the end of each turn";
    this.Image = "Card/Building/TropicalForest";
    this.WoodCost = 3;
    this.FishCost = 0;
    this.GoldCost = 2;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override void EndOfTurn()
  {
    ResourcesManager.Instance.Gain(3, ResourceTypes.Wood);
  }
}