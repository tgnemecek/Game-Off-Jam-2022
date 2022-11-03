using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardPile : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI _counter;

  private List<Card> _cards = new List<Card>();

  public void Discard(Card card)
  {
    _cards.Add(card);
    card.enabled = false;
    _counter.text = _cards.Count.ToString();
  }
}
