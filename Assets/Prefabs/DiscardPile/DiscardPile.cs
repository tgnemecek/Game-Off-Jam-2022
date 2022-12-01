using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardPile : MonoBehaviour, IPile
{
  [SerializeField]
  private TextMeshProUGUI _counter;
  [SerializeField]
  private DeckBook _discardDeckBook;
  private bool _isHovering = false;

  private List<Card> _cards = new List<Card>(); public List<Card> Cards => _cards;

  void Update()
  {
    if (_isHovering && Input.GetMouseButtonDown(0))
    {
      _discardDeckBook.gameObject.SetActive(true);
    }
  }

  public void Discard(Card card)
  {
    _cards.Add(card);
    card.transform.SetParent(transform);
    card.AddToPile(this);
    card.transform.localPosition = Vector3.zero;
    UpdateDisplays();
  }
  public List<Card> UndiscardAllCards()
  {
    var result = _cards;
    _cards = new List<Card>();

    UpdateDisplays();

    return result;
  }

  void UpdateDisplays()
  {
    _counter.text = _cards.Count.ToString();
    _discardDeckBook.SetCards(_cards);
  }

  public void MouseEnter() => _isHovering = true;
  public void MouseExit() => _isHovering = false;
}
