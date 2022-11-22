using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardPile : MonoBehaviour, IPile
{
  [SerializeField]
  private TextMeshProUGUI _counter;
  [SerializeField]
  private DeckBook _deckBook;
  private bool _isHovering = false;

  private List<Card> _cards = new List<Card>();

  void Update()
  {
    if (_isHovering && Input.GetMouseButtonDown(0))
    {
      _deckBook.gameObject.SetActive(true);
    }
  }

  public void Discard(Card card)
  {
    _cards.Add(card);
    card.transform.SetParent(transform);
    card.transform.localPosition = Vector3.zero;
    card.enabled = false;
    _counter.text = _cards.Count.ToString();
    _deckBook.PopulateCards(_cards);
  }
  public void MouseEnter() => _isHovering = true;
  public void MouseExit() => _isHovering = false;
}
