#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_DownTheDrain : Card_Spell
{
  public Card_DownTheDrain()
  {
    this.Id = 35;
		this.Name = "Down the drain";
		this.Description = "Gain 1 Gold for every hit your Core takes this turn";
		this.Image = "Card/Spell/DownTheDrain";
		this.WoodCost = 0;
		this.FishCost = 0;
		this.GoldCost = 5;
		this.MaxHP = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    void Callback()
    {
      ResourcesManager.Instance.Gain(1, ResourceTypes.Gold);
    }
    GameManager.Instance.Core.OnCoreHit.Add(Callback);
  }
}