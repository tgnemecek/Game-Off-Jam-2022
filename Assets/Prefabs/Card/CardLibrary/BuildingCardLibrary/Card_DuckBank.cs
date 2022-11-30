#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_DuckBank : Card_Building
{
  public Card_DuckBank()
  {
    this.Id = 44;
		this.Name = "Duck Bank";
		this.Description = "Gain 5 Gold at the end of each turn";
		this.Image = "Card/Building/DuckBank";
		this.WoodCost = 5;
		this.FishCost = 2;
		this.GoldCost = 2;
		this.MaxHP = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn() { yield break; }
}