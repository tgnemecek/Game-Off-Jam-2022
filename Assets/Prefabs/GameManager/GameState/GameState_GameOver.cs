using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_GameOver : GameState
{
  public GameState_GameOver(GameManager context, GameStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    PlayerController.Instance.CanInteractWithCards = false;
    _context.EnemyManager.DisableAllEnemies();
    _context.GameOverMenu.gameObject.SetActive(true);
  }

  public override void OnCardSelected(Card card) { }
  public override void OnWaveClear() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn() { }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}