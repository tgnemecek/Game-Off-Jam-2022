using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_BoosterPack : GameState
{
  public GameState_BoosterPack(GameManager context, GameStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.IsCardInteractionActive = false;
    _context.BoosterPack.gameObject.SetActive(true);
  }
  public override void OnCardSelected(Card card)
  {
    _context.BoosterPack.Cards.ForEach((Card c) =>
    {
      if (c != card) GameObject.Destroy(c.gameObject);
    });

    var cardsToAdd = _context.DiscardPile.UndiscardAllCards();
    cardsToAdd.Add(card);

    _context.DrawPile.AddCards(cardsToAdd);
    _context.DrawPile.Shuffle();
    _context.BoosterPack.Disable();
    SwitchState(_factory.PlayerTurn());
  }
  public override void OnWaveClear() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn() { }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}