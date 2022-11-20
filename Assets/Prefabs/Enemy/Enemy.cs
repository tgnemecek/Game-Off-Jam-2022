using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private string _name;
  [SerializeField]
  private int _hp = 0;
  [SerializeField]
  private int _damage = 0;
  [SerializeField]
  private Card _target; public Card Target { get { return _target; } set { _target = value; } }
  [HideInInspector]
  public Rigidbody Rigidbody;
  [HideInInspector]
  public Seeker Seeker;
  [SerializeField]
  private EnemyConfig _enemyConfig; public EnemyConfig EnemyConfig => _enemyConfig;

  private EnemyStateFactory _stateFactory;
  private EnemyState _currentState; public EnemyState CurrentState { get { return _currentState; } set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }

  void Awake()
  {
    Rigidbody = GetComponent<Rigidbody>();
    Seeker = GetComponent<Seeker>();
  }

  void Start()
  {
    _stateFactory = new EnemyStateFactory(this);
    _currentState = _stateFactory.NotInPlay();
    _currentState.EnterState();
  }

  void Update()
  {
    _currentState.UpdateState();
  }

  void FixedUpdate()
  {
    _currentState.FixedUpdateState();
  }

  public void EndOfTurn()
  {
    _currentState.EndOfTurn();
  }
}