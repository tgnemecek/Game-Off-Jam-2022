using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
  private List<Card> _cards = new List<Card>(); public List<Card> Cards => _cards;

  public void AddCardToBoard(Card card)
  {
    _cards.Add(card);
    card.transform.SetParent(transform);
  }
  public void RemoveCardFromBoard(Card card)
  {
    _cards.Remove(card);
  }
}
