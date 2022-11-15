using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private string _name;
  [SerializeField]
  private int _hp = 0;
  [SerializeField]
  private int _damage = 0;
  [SerializeField]
  private Transform _target; public Transform Target { get { return _target; } set { _target = value; } }
  [SerializeField]
  private Rigidbody _rb; public Rigidbody Rigidbody => _rb;
  [SerializeField]
  private EnemyConfig _enemyConfig; public EnemyConfig EnemyConfig => _enemyConfig;

  private EnemyStateFactory _stateFactory;
  private EnemyState _currentState; public EnemyState CurrentState { get { return _currentState; } set { _currentState = value; } }

  private bool _drawnOnThisFrame; public bool DrawnOnThisFrame { get { return _drawnOnThisFrame; } set { _drawnOnThisFrame = value; } }

  void Awake() { }

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