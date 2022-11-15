using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBook : MonoBehaviour
{
  private Deck _deck;
  private DrawPile _drawPile;

  [SerializeField]
  private GridLayoutGroup _gridLayoutGroup;

  [SerializeField]
  private GameObject _test;

  private GameObject[][] _tests = { };

  void Awake()
  {
    _drawPile = FindObjectOfType<DrawPile>();
  }

  void OnEnable()
  {
    if (_drawPile.Deck != _deck)
    {
      _deck = _drawPile.Deck;
      PopulateCards();
    }
  }

  void PopulateCards()
  {
    int cardCount = _deck.Cards.Count;

    for (int i = 0; i < cardCount; i++)
    {
      var card = Instantiate(_deck.Cards[i % cardCount]);
      var canvas = card.CardLayerController.Canvas;
      card.CardLayerController.ShowCardForUI();


      canvas.transform.SetParent(_gridLayoutGroup.transform);
      canvas.transform.localScale = Vector3.one;
      Destroy(card.gameObject);
    }
  }
}