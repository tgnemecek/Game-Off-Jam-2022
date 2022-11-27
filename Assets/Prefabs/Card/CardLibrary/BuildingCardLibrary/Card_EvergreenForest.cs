#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;

public class Card_EvergreenForest : Card_Building
{
  public Card_EvergreenForest()
  {
    this.Id = 22;
    this.Name = "Evergreen Forest";
    this.Description = "Gain 4 Wood at the end of each turn";
    this.Image = "Card/Building/EvergreenForest";
    this.WoodCost = 4;
    this.FishCost = 0;
    this.GoldCost = 3;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn()
  {
    ResourcesManager.Instance.Gain(4, ResourceTypes.Wood);
    yield break;
  }
}