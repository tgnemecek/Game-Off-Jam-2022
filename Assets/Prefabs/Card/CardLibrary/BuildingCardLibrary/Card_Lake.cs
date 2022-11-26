#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
public class Card_Lake : Card_Building
{
  public Card_Lake()
  {
    this.Id = 16;
    this.Name = "Lake";
    this.Description = "Gain 2 Fish at the end of each turn";
    this.Image = "Card/Building/Lake";
    this.WoodCost = 0;
    this.FishCost = 2;
    this.GoldCost = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override void EndOfTurn()
  {
    ResourcesManager.Instance.Gain(2, ResourceTypes.Fish);
  }
}