public abstract class GameState
{
  protected GameManager _context;
  protected GameStateFactory _factory;

  public GameState(GameManager context, GameStateFactory factory)
  {
    _context = context;
    _factory = factory;
  }

  protected void SwitchState(GameState newState)
  {
    ExitState();
    _context.CurrentState = newState;
    newState.EnterState();
  }
  public abstract void OnCardSelected(Card card);
  public abstract void OnWaveClear();
  public abstract void EnterState();
  public abstract void UpdateState();
  public abstract void FixedUpdateState();
  public abstract void EndPlayerTurn();
  public abstract void EndEnemyTurn();
  public abstract void ExitState();
}