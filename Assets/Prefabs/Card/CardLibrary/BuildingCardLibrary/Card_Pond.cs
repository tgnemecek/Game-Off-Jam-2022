#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_Pond : Card_Building
{
  public Card_Pond()
  {
    this.Id = 15;
		this.Name = "Pond";
		this.Description = "Gain 1 Fish at the end of each turn";
		this.Image = "Card/Building/Pond";
		this.WoodCost = 0;
		this.FishCost = 1;
		this.GoldCost = 1;
		this.MaxHP = 9;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    // TODO: Add logic
  }

  public override IEnumerator EndOfTurn()
  {
    yield return base.EndOfTurn();
    ResourcesManager.Instance.Gain(1, ResourceTypes.Fish);
  }
}