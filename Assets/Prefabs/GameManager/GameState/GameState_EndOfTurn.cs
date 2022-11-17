using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_EndOfTurn : GameState
{
  public GameState_EndOfTurn(GameManager context, GameStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.IsCardInteractionActive = false;
    _context.StartCoroutine(HandleEndOfTurnTasks());
  }

  IEnumerator HandleEndOfTurnTasks()
  {
    var cardsInBoard = _context.Board.Cards;

    for (int i = 0; i < cardsInBoard.Count; i++)
    {
      var card = cardsInBoard[i];
      card.EndOfTurn();
      yield return new WaitForSeconds(_context.GameConfig.DelayBetweenEndOfTurnTasks);
    }

    SwitchState(_factory.EnemyTurn());
  }

  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn() { }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}