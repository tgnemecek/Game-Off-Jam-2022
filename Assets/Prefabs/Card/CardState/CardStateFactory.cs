using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CardStateEnum
{
  NotInPlay,
  InHand,
  InBoard,
  Dragged
}

public class CardStateFactory
{
  Card _context;
  Dictionary<CardStateEnum, CardState> _states = new Dictionary<CardStateEnum, CardState>();

  public CardStateFactory(Card context)
  {
    _context = context;
    _states[CardStateEnum.NotInPlay] = new CardState_NotInPlay(_context, this);
    _states[CardStateEnum.InHand] = new CardState_InHand(_context, this);
    _states[CardStateEnum.InBoard] = new CardState_InBoard(_context, this);
    _states[CardStateEnum.Dragged] = new CardState_Dragged(_context, this);
  }

  public CardState NotInPlay() => _states[CardStateEnum.NotInPlay];
  public CardState InHand() => _states[CardStateEnum.InHand];
  public CardState InBoard() => _states[CardStateEnum.InBoard];
  public CardState Dragged() => _states[CardStateEnum.Dragged];
}
