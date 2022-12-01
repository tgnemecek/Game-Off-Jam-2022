#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_PlentyOfFishInTheSea : Card_Item
{
  public Card_PlentyOfFishInTheSea()
  {
    this.Id = 13;
		this.Name = "Plenty of fish in the sea";
		this.Description = "Gain 3 Fish";
		this.Image = "Card/Item/PlentyOfFishInTheSea";
		this.WoodCost = 1;
		this.FishCost = 0;
		this.GoldCost = 0;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(3, ResourceTypes.Fish);
  }
}