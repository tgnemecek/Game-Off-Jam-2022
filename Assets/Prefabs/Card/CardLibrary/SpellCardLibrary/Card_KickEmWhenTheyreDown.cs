#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_KickEmWhenTheyreDown : Card_Spell
{
  public Card_KickEmWhenTheyreDown()
  {
    this.Id = 24;
    this.Name = "Kick 'em when they're down";
    this.Description = "Your Units are invulnerable next turn. Your Core loses 50% of Max HP";
    this.Image = "Card/Spell/KickEmWhenTheyreDown";
    this.WoodCost = 0;
    this.FishCost = 3;
    this.GoldCost = 0;
    this.MaxHP = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    GameManager gm = GameManager.Instance;

    gm.Board.Cards
      .FindAll((Card card) => card.Type == CardTypes.Unit)
      .ForEach((Card card) => card.Invulnerable = true);

    int amount = Mathf.FloorToInt((float)gm.Core.MaxHP * .5f);
    gm.Core.ReceiveDamage(amount);
  }
}