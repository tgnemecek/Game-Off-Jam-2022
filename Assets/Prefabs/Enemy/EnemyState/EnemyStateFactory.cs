using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStateEnum
{
  NotInPlay,
  Hunting,
  InBattle,
  Attacking,
  Attacked,
  Dead,
}

public class EnemyStateFactory
{
  Enemy _context;
  Dictionary<EnemyStateEnum, EnemyState> _states = new Dictionary<EnemyStateEnum, EnemyState>();

  public EnemyStateFactory(Enemy context)
  {
    _context = context;
    _states[EnemyStateEnum.NotInPlay] = new EnemyState_NotInPlay(_context, this);
    _states[EnemyStateEnum.Hunting] = new EnemyState_Hunting(_context, this);
    _states[EnemyStateEnum.InBattle] = new EnemyState_InBattle(_context, this);
    _states[EnemyStateEnum.Attacking] = new EnemyState_Attacking(_context, this);
    _states[EnemyStateEnum.Attacked] = new EnemyState_Attacked(_context, this);
    _states[EnemyStateEnum.Dead] = new EnemyState_Dead(_context, this);
  }

  public EnemyState NotInPlay() => _states[EnemyStateEnum.NotInPlay];
  public EnemyState Hunting() => _states[EnemyStateEnum.Hunting];
  public EnemyState InBattle() => _states[EnemyStateEnum.InBattle];
  public EnemyState Attacking() => _states[EnemyStateEnum.Attacking];
  public EnemyState Attacked() => _states[EnemyStateEnum.Attacked];
  public EnemyState Dead() => _states[EnemyStateEnum.Dead];
}