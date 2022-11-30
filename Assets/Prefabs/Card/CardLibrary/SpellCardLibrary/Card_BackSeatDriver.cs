#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_BackSeatDriver : Card_Spell
{
  public Card_BackSeatDriver()
  {
    this.Id = 37;
		this.Name = "Back-seat driver";
		this.Description = "Heal your Core by 10% and sacrifice a random Unit";
		this.Image = "Card/Spell/BackSeatDriver";
		this.WoodCost = 4;
		this.FishCost = 4;
		this.GoldCost = 0;
		this.MaxHP = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    Core core = GameManager.Instance.Core;

    int amount = Mathf.CeilToInt((float)core.MaxHP * .1f);
    GameManager.Instance.Core.Heal(amount);


    var cards = GameManager.Instance.Board.Cards
      .FindAll((Card card) => card.Type == CardTypes.Unit);

    int randomIndex = UnityEngine.Random.Range(0, cards.Count - 1);
    Card card = cards[randomIndex];
    card.ReceiveDamage(99999);
  }
}