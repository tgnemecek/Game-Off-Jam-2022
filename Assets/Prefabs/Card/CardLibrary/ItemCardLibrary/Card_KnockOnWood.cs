#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_KnockOnWood : Card_Item
{
  public Card_KnockOnWood()
  {
    this.Id = 14;
		this.Name = "Knock on wood";
		this.Description = "Gain 3 Wood";
		this.Image = "Card/Item/KnockOnWood";
		this.WoodCost = 0;
		this.FishCost = 1;
		this.GoldCost = 0;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(3, ResourceTypes.Wood);
  }
}