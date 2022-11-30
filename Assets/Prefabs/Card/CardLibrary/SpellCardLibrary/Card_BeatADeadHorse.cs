#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_BeatADeadHorse : Card_Spell
{
  public Card_BeatADeadHorse()
  {
    this.Id = 38;
		this.Name = "Beat a dead horse";
		this.Description = "Gain a 1 Gold for each enemy defeated next turn";
		this.Image = "Card/Spell/BeatADeadHorse";
		this.WoodCost = 4;
		this.FishCost = 2;
		this.GoldCost = 0;
		this.MaxHP = 0;
  }

  #endregion AUTO-GENERATED

  delegate void MyDelegate();
  MyDelegate attack;

  public override void Play()
  {
    void Callback()
    {
      ResourcesManager.Instance.Gain(1, ResourceTypes.Gold);
    };
    GameManager.Instance.EnemyManager.OnEnemyKilled.Add(Callback);
  }
}