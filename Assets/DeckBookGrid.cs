using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBookGrid : MonoBehaviour
{

  [SerializeField]
  private Deck _deck;


  // Start is called before the first frame update
  void Start()
  {
    int cardCount = _deck.Cards.Count;

    for (int i = 0; i < 100; i++)
    {
      Card card = Instantiate(_deck.Cards[i % cardCount], transform);
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
