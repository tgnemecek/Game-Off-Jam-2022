using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pathfinding;

public class Enemy : MonoBehaviour
{
  [Header("Dependencies")]
  [SerializeField]
  private string _name;
  [SerializeField]
  private int _hp = 0;
  [SerializeField]
  private int _damage = 0;
  [SerializeField]
  private IHitable _target; public IHitable Target { get { return _target; } set { _target = value; } }
  [SerializeField]
  private EnemyConfig _enemyConfig; public EnemyConfig EnemyConfig => _enemyConfig;
  [SerializeField]
  private Core _core; public Core Core => _core;
  [SerializeField]
  private CardProximityDetector _cardProximityDetector; public CardProximityDetector CardProximityDetector => _cardProximityDetector;
  [HideInInspector]
  public Rigidbody Rigidbody;
  [HideInInspector]
  public Seeker Seeker;
  [Header("Debug Options")]
  [ReadOnly] public string CurrentStateName;

  private EnemyStateFactory _stateFactory;
  private EnemyState _currentState; public EnemyState CurrentState { get { return _currentState; } set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }

  void Awake()
  {
    Rigidbody = GetComponent<Rigidbody>();
    Seeker = GetComponent<Seeker>();
    _core = GameManager.Instance.Core;
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
    CurrentStateName = _currentState.GetType().Name;
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