using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBookGrid : MonoBehaviour
{

  [SerializeField]
  private Deck _deck;

  private GridLayoutGroup _gridLayoutGroup;

  // Start is called before the first frame update
  void Start()
  {
    _gridLayoutGroup = GetComponent<GridLayoutGroup>();

    PopulateCards();
  }

  void PopulateCards()
  {
    int cardCount = _deck.Cards.Count;

    for (int i = 0; i < 100; i++)
    {
      Card card = Instantiate(_deck.Cards[i % cardCount], transform);
      card.ShowCardFront();
    }
  }
}