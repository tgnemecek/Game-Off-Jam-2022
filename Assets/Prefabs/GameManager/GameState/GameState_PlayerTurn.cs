using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_PlayerTurn : GameState
{
  public GameState_PlayerTurn(GameManager context, GameStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.IsCardInteractionActive = true;
    _context.Hand.DrawHand();
  }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn()
  {
    SwitchState(_factory.EndOfTurn());
  }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}