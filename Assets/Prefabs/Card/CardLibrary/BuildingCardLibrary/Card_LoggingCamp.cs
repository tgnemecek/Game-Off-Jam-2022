#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;

public class Card_LoggingCamp : Card_Building
{
  public Card_LoggingCamp()
  {
    this.Id = 19;
    this.Name = "Logging Camp";
    this.Description = "Gain 1 Wood at the end of each turn";
    this.Image = "Card/Building/LoggingCamp";
    this.WoodCost = 1;
    this.FishCost = 0;
    this.GoldCost = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn()
  {
    ResourcesManager.Instance.Gain(1, ResourceTypes.Wood);
    yield break;
  }
}