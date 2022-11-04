using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
  [SerializeField]
  int _drawUpTo;
  private List<Card> _cards = new List<Card>();

  [SerializeField]
  DrawPile _drawPile;

  [SerializeField]
  DiscardPile _discardPile;

  [SerializeField]
  ResourcesManager _resourcesManager;

  public void DrawHand()
  {
    int cardsInHand = _cards.Count;
    if (cardsInHand >= _drawUpTo) return;

    for (int i = cardsInHand; i <= _drawUpTo; i++)
    {
      Card card = _drawPile.TryDraw();
      if (card != null)
      {
        card.transform.SetParent(transform);
        _cards.Add(card);
      }
    }
    PositionCardsInHand();
  }

  void PositionCardsInHand()
  {
    float space = 1.8f;
    float movementTime = 1f;

    List<float> positionsX = new List<float>();

    float firstElementX = 0;
    float lastElementX = 0;

    for (int i = 0; i < _cards.Count; i++)
    {
      var card = _cards[i];
      float x = i * space;

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

      _cards[i].Draw(_resourcesManager, this, worldPos);
      LeanTween.rotateAround(_cards[i].gameObject, Vector3.up, -180f, movementTime).setDelay(delay).setEaseInOutCubic();
    }
  }

  public void DiscardCard(Card card)
  {
    _cards.Remove(card);
    card.enabled = false;
    _discardPile.Discard(card);
  }
}
