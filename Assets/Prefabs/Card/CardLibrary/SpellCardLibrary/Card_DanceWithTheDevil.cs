#region AUTO-GENERATED
// Do not manually change code within the AUTO-GENERATED region. Instead update the Card Library spreadsheet and run npm build-cards
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card_DanceWithTheDevil : Card_Spell
{
  public Card_DanceWithTheDevil()
  {
    this.Id = 43;
		this.Name = "Dance with the devil";
		this.Description = "Your Core is invulnerable next turn. Sacrifice a random Building.";
		this.Image = "Card/Spell/DanceWithTheDevil";
		this.WoodCost = 2;
		this.FishCost = 2;
		this.GoldCost = 2;
		this.MaxHP = 1;
  }

  #endregion AUTO-GENERATED

  public override void Play()
  {
    GameManager.Instance.Core.Invulnerable = true;

    var cards = GameManager.Instance.Board.Cards
      .FindAll((Card card) => card.Type == CardTypes.Building);

    int randomIndex = UnityEngine.Random.Range(0, cards.Count - 1);
    Card card = cards[randomIndex];
    card.ReceiveDamage(99999);
  }
}