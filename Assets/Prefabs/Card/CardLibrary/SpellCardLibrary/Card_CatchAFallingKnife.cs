#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_CatchAFallingKnife : Card_Spell
{
  public Card_CatchAFallingKnife()
  {
    this.Id = 31;
		this.Name = "Catch a falling knife";
		this.Description = "Draw until you have 5 cards. Discard all Units from your hand";
		this.Image = "Card/Spell/CatchAFallingKnife";
		this.WoodCost = 0;
		this.FishCost = 0;
		this.GoldCost = 7;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    Hand hand = GameManager.Instance.Hand;
    hand.DrawHand(5);
    var cards = hand.Cards;

    foreach (var card in hand.Cards)
    {
      if (card.Type == CardTypes.Unit)
      {
        hand.RemoveCard(card);
        GameManager.Instance.DiscardPile.Discard(card);
      }
    }
  }
}