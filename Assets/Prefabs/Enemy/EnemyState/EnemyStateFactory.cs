using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyStateEnum
{
  NotInPlay,
  Hunting,
  Attacking,
  Attacked,
  Dying,
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
    _states[EnemyStateEnum.Attacking] = new EnemyState_Attacking(_context, this);
    _states[EnemyStateEnum.Attacked] = new EnemyState_Attacked(_context, this);
    _states[EnemyStateEnum.Dying] = new EnemyState_Dying(_context, this);
  }

  public EnemyState NotInPlay() => _states[EnemyStateEnum.NotInPlay];
  public EnemyState Hunting() => _states[EnemyStateEnum.Hunting];
  public EnemyState Attacking() => _states[EnemyStateEnum.Attacking];
  public EnemyState Attacked() => _states[EnemyStateEnum.Attacked];
  public EnemyState Dying() => _states[EnemyStateEnum.Dying];
}
