using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckGrid : MonoBehaviour
{
  [SerializeField]
  private Deck _deck;

  [SerializeField]
  ResourcesManager _resourcesManager;


  // Start is called before the first frame update
  void Start()
  {

    int cardCount = _deck.Cards.Count;

    for (int i = 0; i < cardCount; i++)
    {
      Debug.Log(_deck.Cards[i]);
      Card card = Instantiate(_deck.Cards[i], transform);
      card.enabled = true;
      card.gameObject.SetActive(true); 
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}
