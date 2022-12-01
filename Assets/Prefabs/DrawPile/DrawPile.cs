using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPile : MonoBehaviour, IPile
{
  [SerializeField]
  private TextMeshProUGUI _counter;
  [SerializeField]
  private DeckBook _drawDeckBook;
  private List<Card> _cards = new List<Card>(); public List<Card> Cards => _cards;
  private bool _isHovering = false;

  void Update()
  {
    if (_isHovering && Input.GetMouseButtonDown(0))
    {
      _drawDeckBook.gameObject.SetActive(true);
    }
  }

  public void AddCards(List<Card> cards)
  {
    foreach (var c in cards)
    {
      Card card;
      if (c.WasInitialized)
      {
        card = c;
        card.transform.SetParent(transform);
        card.AddToPile(this);
      }
      else
      {
        card = Instantiate(c, transform.position, Quaternion.Euler(-90, -180, 0), transform);
        card.Initialize(CardStateEnum.InPile);
      }
      _cards.Add(card);
    }

    _drawDeckBook.SetCards(_cards);
  }

  public void Shuffle()
  {
    var newList = new List<Card>();

    while (_cards.Count > 0)
    {
      int randomIndex = UnityEngine.Random.Range(0, _cards.Count);
      var card = _cards[randomIndex];
      newList.Add(card);
      _cards.Remove(card);
    }
    _cards = newList;
    UpdateCounter();
  }

  void UpdateCounter()
  {
    if (_cards.Count == 0) _counter.text = "";
    else _counter.text = _cards.Count.ToString();
  }

  public void MouseEnter() => _isHovering = true;
  public void MouseExit() => _isHovering = false;

#nullable enable
  public Card? TryDraw()
  {
    if (_cards.Count == 0) return null;
    int lastIndex = _cards.Count - 1;
    var card = _cards[lastIndex];
    _cards.RemoveAt(lastIndex);
    _drawDeckBook.SetCards(_cards);
    UpdateCounter();
    return card;
  }
}
