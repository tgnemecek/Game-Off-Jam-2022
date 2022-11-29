#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;

public class Card_Fish : Card_Resource
{
  public Card_Fish()
  {
    this.Id = 2;
    this.Name = "Fish";
    this.Description = "";
    this.Image = "Card/Resource/Fish";
    this.WoodCost = 0;
    this.FishCost = 0;
    this.GoldCost = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(1, ResourceTypes.Fish);
  }
}