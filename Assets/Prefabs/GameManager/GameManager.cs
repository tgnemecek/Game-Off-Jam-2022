using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
  private static GameManager _instance;

  public static GameManager Instance { get { return _instance; } }

  [SerializeField]
  private Board _board; public Board Board => _board;
  [SerializeField]
  private GameOverMenu _gameOverMenu; public GameOverMenu GameOverMenu => _gameOverMenu;
  [SerializeField]
  private GameConfig _gameConfig; public GameConfig GameConfig => _gameConfig;
  [SerializeField]
  private EnemyManager _enemyManager; public EnemyManager EnemyManager => _enemyManager;
  [SerializeField]
  private DeckBook _deckBook; public DeckBook DeckBook => _deckBook;
  [SerializeField]
  private Hand _hand; public Hand Hand => _hand;
  [SerializeField]
  private Core _core; public Core Core => _core;
  [SerializeField]
  private DrawPile _drawPile; public DrawPile DrawPile => _drawPile;
  [SerializeField]
  private DiscardPile _discardPile; public DiscardPile DiscardPile => _discardPile;
  [SerializeField]
  private Deck _deck; public Deck Deck => _deck;
  [SerializeField]
  private BoosterPack _boosterPack; public BoosterPack BoosterPack => _boosterPack;
  private int _waveCounter; public int WaveCount => _waveCounter;
  [SerializeField]
  private TextMeshProUGUI _waveText;
  [Header("Debug Options")]
  public string CurrentStateName;

  private GameStateFactory _stateFactory;
  private GameState _currentState; public GameState CurrentState { set { _currentState = value; } }

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
    _waveCounter = 0;
    UpdateWaveText();

    _deckBook.SetCards(_deck.Cards);

    _drawPile.AddCards(_deck.Cards);
    _drawPile.Shuffle();
  
    _stateFactory = new GameStateFactory(this);
    _currentState = _stateFactory.PlayerTurn();
    _currentState.EnterState();
  }

  void Update()
  {
    CurrentStateName = _currentState?.GetType().Name;
  }

  void UpdateWaveText()
  {
    _waveText.text = "Wave: " + _waveCounter;
  }

  public void OnWaveStart()
  {
    _waveCounter++;
    UpdateWaveText();
  }

  public void OnWaveClear()
  {
    _currentState.OnWaveClear();
  } 
  public void OnCardSelected(Card card) => _currentState.OnCardSelected(card);

  public void GameOver()
  {
    _currentState.ExitState();
    _currentState = _stateFactory.GameOver();
    _currentState.EnterState();
  }
  public void QuitGame() => Application.Quit();

  public void EndPlayerTurn() => _currentState?.EndPlayerTurn();
  public void EndEnemyTurn() => _currentState?.EndEnemyTurn();
}
