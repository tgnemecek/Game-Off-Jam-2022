#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_Fishing : Card_Item
{
  public Card_Fishing()
  {
    this.Id = 11;
		this.Name = "Fishing";
		this.Description = "Gain 2 Fish";
		this.Image = "Card/Item/Fishing";
		this.WoodCost = 1;
		this.FishCost = 0;
		this.GoldCost = 0;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(2, ResourceTypes.Fish);
  }
}