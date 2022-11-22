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
  public override void OnWaveClear() { }
  public override void UpdateState() { }
  public override void FixedUpdateState() { }
  public override void EndPlayerTurn() { }
  public override void EndEnemyTurn() { }
  public override void ExitState() { }
}