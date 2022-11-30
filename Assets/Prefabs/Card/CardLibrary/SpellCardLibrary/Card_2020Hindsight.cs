#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_2020Hindsight : Card_Spell
{
  public Card_2020Hindsight()
  {
    this.Id = 30;
		this.Name = "20 20 hindsight";
		this.Description = "Shuffle your Hand and Discard Pile into your Draw Pile. Draw 3 cards";
		this.Image = "Card/Spell/2020Hindsight";
		this.WoodCost = 4;
		this.FishCost = 1;
		this.GoldCost = 0;
		this.MaxHP = 0;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    var discardedCards = GameManager.Instance.DiscardPile.UndiscardAllCards();
    var cardsInHand = GameManager.Instance.Hand.RemoveAllCards();

    var total = new List<Card>(discardedCards);
    total.AddRange(cardsInHand);

    GameManager.Instance.DrawPile.AddCards(total);
    GameManager.Instance.DrawPile.Shuffle();

    GameManager.Instance.Hand.DrawHand(3);
  }
}