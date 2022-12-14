using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardStateEnum
{
  NotInPlay,
  InBooster,
  InPile,
  InHand,
  InBoard,
  Dragged,
  Consumed,
  Destroyed
}

public class CardStateFactory
{
  Card _context;
  Dictionary<CardStateEnum, CardState> _states = new Dictionary<CardStateEnum, CardState>();

  public CardStateFactory(Card context)
  {
    _context = context;
    _states[CardStateEnum.NotInPlay] = new CardState_NotInPlay(_context, this);
    _states[CardStateEnum.InBooster] = new CardState_InBooster(_context, this);
    _states[CardStateEnum.InPile] = new CardState_InPile(_context, this);
    _states[CardStateEnum.InHand] = new CardState_InHand(_context, this);
    _states[CardStateEnum.InBoard] = new CardState_InBoard(_context, this);
    _states[CardStateEnum.Dragged] = new CardState_Dragged(_context, this);
    _states[CardStateEnum.Consumed] = new CardState_Consumed(_context, this);
    _states[CardStateEnum.Destroyed] = new CardState_Destroyed(_context, this);
  }

  public CardState NotInPlay() => _states[CardStateEnum.NotInPlay];
  public CardState InBooster() => _states[CardStateEnum.InBooster];
  public CardState InPile() => _states[CardStateEnum.InPile];
  public CardState InHand() => _states[CardStateEnum.InHand];
  public CardState InBoard() => _states[CardStateEnum.InBoard];
  public CardState Dragged() => _states[CardStateEnum.Dragged];
  public CardState Consumed() => _states[CardStateEnum.Consumed];
  public CardState Destroyed() => _states[CardStateEnum.Destroyed];
}