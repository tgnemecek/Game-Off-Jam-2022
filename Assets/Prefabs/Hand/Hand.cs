using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
  [SerializeField]
  private int _drawUpTo;
  [SerializeField]
  private float _drawDelay = 0f;

  private List<Card> _cards = new List<Card>(); public List<Card> Cards => _cards;

  [SerializeField]
  private float _spaceBetweenCardsInHand;

  public void DrawHand() => DrawHand(_drawUpTo);
  public void DrawHand(int upTo)
  {
    Debug.Break();
    var drawPile = GameManager.Instance.DrawPile;

    int cardsInHand = _cards.Count;
    if (cardsInHand >= _drawUpTo) return;

    int cardsToDraw = _drawUpTo - cardsInHand;

    for (int i = 0; i < cardsToDraw; i++)
    {
      Card card = drawPile.TryDraw();
      if (card != null)
      {
        _cards.Add(card);
      }
    }

    CalculateHandPositions();

    StartCoroutine(DrawCards());
  }

  IEnumerator DrawCards()
  {
    for (int i = 0; i < _cards.Count; i++)
    {
      float delay = _drawDelay * i;
      yield return new WaitForSeconds(delay);
      _cards[i].Draw();
    }
  }

  void CalculateHandPositions()
  {
    List<float> positionsX = new List<float>();
    float firstElementX = 0;
    float lastElementX = 0;

    for (int i = 0; i < _cards.Count; i++)
    {
      Card card = _cards[i];
      float x = i * _spaceBetweenCardsInHand;

      if (i == 0) firstElementX = x;
      if (i == _cards.Count - 1) lastElementX = x;

      if (i == 0) firstElementX = x;
      if (i == _cards.Count - 1) lastElementX = x;
      positionsX.Add(x);
    }

    for (int i = 0; i < positionsX.Count; i++)
    {
      float x = positionsX[i];
      float delay = i * .2f;

      var worldPos = new Vector3(
        x + ((firstElementX - lastElementX) / 2),
        transform.position.y,
        transform.position.z
      );

      _cards[i].SetPositionInHand(worldPos);
    }
  }

  public void RemoveCard(Card card)
  {
    _cards.Remove(card);
    CalculateHandPositions();
  }
  public List<Card> RemoveAllCards()
  {
    var cards = new List<Card>(_cards);
    _cards.Clear();
    return cards;
  }
}
