#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_DressedToKill : Card_Spell
{
  public Card_DressedToKill()
  {
    this.Id = 36;
    this.Name = "Dressed to kill";
    this.Description = "A random unit is completely healed";
    this.Image = "Card/Spell/DressedToKill";
    this.WoodCost = 0;
    this.FishCost = 0;
    this.GoldCost = 0;
    this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    var cards = GameManager.Instance.Board.Cards
      .FindAll((Card card) => card.Type == CardTypes.Unit);

    if (cards.Count > 0)
    {
      int randomIndex = UnityEngine.Random.Range(0, cards.Count);
      Card card = cards[randomIndex];
      card.Heal(99999);
    }

  }
}