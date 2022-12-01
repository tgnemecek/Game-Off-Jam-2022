#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_LumberMill : Card_Building
{
  public Card_LumberMill()
  {
    this.Id = 20;
		this.Name = "Lumber Mill";
		this.Description = "Gain 2 Wood and 1 Gold at the end of each turn";
		this.Image = "Card/Building/LumberMill";
		this.WoodCost = 2;
		this.FishCost = 0;
		this.GoldCost = 1;
		this.MaxHP = 16;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn()
  {
    yield return base.EndOfTurn();
    ResourcesManager.Instance.Gain(2, ResourceTypes.Wood);
    ResourcesManager.Instance.Gain(1, ResourceTypes.Gold);
  }
}