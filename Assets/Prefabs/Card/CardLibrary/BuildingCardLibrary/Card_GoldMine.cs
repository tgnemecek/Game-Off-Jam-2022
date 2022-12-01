#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_GoldMine : Card_Building
{
  public Card_GoldMine()
  {
    this.Id = 21;
		this.Name = "Gold Mine";
		this.Description = "Gain 2 Gold at the end of each turn";
		this.Image = "Card/Building/GoldMine";
		this.WoodCost = 3;
		this.FishCost = 1;
		this.GoldCost = 2;
		this.MaxHP = 25;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn()
  {
    yield return base.EndOfTurn();
    ResourcesManager.Instance.Gain(2, ResourceTypes.Gold);
  }
}