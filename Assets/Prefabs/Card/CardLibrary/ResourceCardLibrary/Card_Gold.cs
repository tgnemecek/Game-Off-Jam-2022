#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_Gold : Card_Resource
{
  public Card_Gold()
  {
    this.Id = 3;
		this.Name = "Gold";
		this.Description = "";
		this.Image = "Card/Resource/Gold";
		this.WoodCost = 0;
		this.FishCost = 0;
		this.GoldCost = 0;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    ResourcesManager.Instance.Gain(1, ResourceTypes.Gold);
  }
}