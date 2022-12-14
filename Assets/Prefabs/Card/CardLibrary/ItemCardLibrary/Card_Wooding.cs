#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_Wooding : Card_Item
{
  public Card_Wooding()
  {
    this.Id = 12;
		this.Name = "Wooding";
		this.Description = "Gain 2 Wood";
		this.Image = "Card/Item/Wooding";
		this.WoodCost = 0;
		this.FishCost = 0;
		this.GoldCost = 1;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(2, ResourceTypes.Wood);
  }
}