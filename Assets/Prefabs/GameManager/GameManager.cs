using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;

  public static GameManager Instance { get { return _instance; } }

  [SerializeField]
  private Board _board; public Board Board => _board;
  [SerializeField]
  private GameConfig _gameConfig; public GameConfig GameConfig => _gameConfig;
  [SerializeField]
  private EnemyManager _enemyManager; public EnemyManager EnemyManager => _enemyManager;
  [SerializeField]
  private Hand _hand; public Hand Hand => _hand;
  [SerializeField]
  private Core _core; public Core Core => _core;

  private GameStateFactory _stateFactory;
  private GameState _currentState; public GameState CurrentState { set { _currentState = value; } }

  [HideInInspector]
  public bool IsCardInteractionActive = false;

  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }
  }

  void Start()
  {
    _stateFactory = new GameStateFactory(this);
    StartCoroutine(WaitAndStartTurn());
  }

  public void GameOver()
  {

  }

  IEnumerator WaitAndStartTurn()
  {
    yield return new WaitForSeconds(3f);
    _currentState = _stateFactory.PlayerTurn();
    _currentState.EnterState();
  }

  public void EndPlayerTurn() => _currentState?.EndPlayerTurn();
  public void EndEnemyTurn() => _currentState?.EndEnemyTurn();
}
