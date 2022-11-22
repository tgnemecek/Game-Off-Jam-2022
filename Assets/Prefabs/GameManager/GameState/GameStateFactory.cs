using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameStateEnum
{
  PlayerTurn,
  EndOfTurn,
  EnemyTurn,
  BoosterPack,
  GameOver
}

public class GameStateFactory
{
  GameManager _context;
  Dictionary<GameStateEnum, GameState> _states = new Dictionary<GameStateEnum, GameState>();

  public GameStateFactory(GameManager context)
  {
    _context = context;
    _states[GameStateEnum.PlayerTurn] = new GameState_PlayerTurn(_context, this);
    _states[GameStateEnum.EndOfTurn] = new GameState_EndOfTurn(_context, this);
    _states[GameStateEnum.EnemyTurn] = new GameState_EnemyTurn(_context, this);
    _states[GameStateEnum.BoosterPack] = new GameState_BoosterPack(_context, this);
    _states[GameStateEnum.GameOver] = new GameState_GameOver(_context, this);
  }

  public GameState PlayerTurn() => _states[GameStateEnum.PlayerTurn];
  public GameState EndOfTurn() => _states[GameStateEnum.EndOfTurn];
  public GameState EnemyTurn() => _states[GameStateEnum.EnemyTurn];
  public GameState BoosterPack() => _states[GameStateEnum.BoosterPack];
  public GameState GameOver() => _states[GameStateEnum.GameOver];
}