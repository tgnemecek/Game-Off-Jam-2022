#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;

public class Card_MiningSite : Card_Building
{
  public Card_MiningSite()
  {
    this.Id = 21;
    this.Name = "Mining Site";
    this.Description = "Gain 2 Gold at the end of each turn";
    this.Image = "undefined";
    this.WoodCost = 3;
    this.FishCost = 0;
    this.GoldCost = 2;
    this.MaxHP = 3;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn() { yield break; }
}