using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_PlayerTurn : GameState
{
  public GameState_PlayerTurn(GameManager context, GameStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    PlayerController.Instance.CanInteractWithCards = true;
    _context.Hand.DrawHand();
    _context.Core.Invulnerable = false;
    _context.Core.OnCoreHit.Clear();
    _context.Board.Cards.ForEach((Card card) => card.Invulnerable = false);
  }

  public override void OnCardSelected(Card card) { }
  public override void OnWaveClear() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn()
  {
    SwitchState(_factory.EndOfTurn());
  }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}