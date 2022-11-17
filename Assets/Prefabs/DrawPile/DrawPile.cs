using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPile : MonoBehaviour
{
  [SerializeField]
  private Deck _deck; public Deck Deck => _deck;
  [SerializeField]
  private TextMeshProUGUI _counter;

  private Stack<Card> _cards = new Stack<Card>();

  void Awake() => Shuffle();

  void Shuffle()
  {
    _cards.Clear();

    var tempList = new List<Card>(_deck.Cards);

    while (tempList.Count > 0)
    {
      int randomIndex = UnityEngine.Random.Range(0, tempList.Count - 1);
      var card = Instantiate(tempList[randomIndex], transform.position, Quaternion.Euler(-90, -180, 0), transform);
      _cards.Push(card);
      card.CardLayerController.SetDrawPileLayer();
      card.CardLayerController.ShowCardBack();
      tempList.RemoveAt(randomIndex);

      if (_cards.Count == 0) _counter.text = "";
      else _counter.text = _cards.Count.ToString();
    }
  }

#nullable enable
  public Card? TryDraw()
  {
    if (_cards.Count == 0) return null;

    var card = _cards.Pop();
    _counter.text = _cards.Count.ToString();
    return card;
  }
}
