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
    newState.EnterState();
    _context.CurrentState = newState;
  }


  public abstract void EnterState();
  public abstract void UpdateState();
  public abstract void FixedUpdateState();
  public abstract void EndPlayerTurn();
  public abstract void EndEnemyTurn();
  public abstract void ExitState();
}