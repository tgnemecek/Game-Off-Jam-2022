#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;

public class Card_Ocean : Card_Building
{
  public Card_Ocean()
  {
    this.Id = 18;
    this.Name = "Ocean";
    this.Description = "Gain 4 Fish at the end of each turn";
    this.Image = "Card/Building/Ocean";
    this.WoodCost = 0;
    this.FishCost = 4;
    this.GoldCost = 3;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn()
  {
    yield return base.EndOfTurn();
    ResourcesManager.Instance.Gain(4, ResourceTypes.Fish);
  }
}