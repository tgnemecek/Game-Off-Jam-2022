using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_EnemyTurn : GameState
{
  public GameState_EnemyTurn(GameManager context, GameStateFactory factory) : base(context, factory) { }


  public override void EnterState()
  {
    _context.IsCardInteractionActive = false;
    _context.EnemyManager.SpawnNextWave();
    AudioManager.Instance.PlayEndTurn();
  }

  public override void UpdateState()
  {
    if (!_context.EnemyManager.AreEnemiesStillAlive())
    {
      SwitchState(_factory.PlayerTurn());
    }
  }
  public override void OnWaveClear()
  {
    _context.StartCoroutine(WaitBeforeExiting());
  }

  IEnumerator WaitBeforeExiting()
  {
    yield return new WaitForSeconds(2f);
    if (_context.DrawPile.Cards.Count == 0)
    {
      SwitchState(_factory.BoosterPack());
    }
    else SwitchState(_factory.PlayerTurn());
  }


  public override void OnCardSelected(Card card) { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn() { }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}