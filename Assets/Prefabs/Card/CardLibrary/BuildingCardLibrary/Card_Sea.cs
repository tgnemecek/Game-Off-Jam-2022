#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_Sea : Card_Building
{
  public Card_Sea()
  {
    this.Id = 17;
		this.Name = "Sea";
		this.Description = "Gain 3 Fish at the end of each turn";
		this.Image = "Card/Building/Sea";
		this.WoodCost = 0;
		this.FishCost = 3;
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
    ResourcesManager.Instance.Gain(3, ResourceTypes.Fish);
  }
}