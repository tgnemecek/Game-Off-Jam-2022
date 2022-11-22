using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckBook : MonoBehaviour
{
  [SerializeField]
  private string _title = "";
  [SerializeField]
  private TextMeshProUGUI _textMesh;
  [SerializeField]
  private GridLayoutGroup _gridLayoutGroup;

  void Start()
  {
    _textMesh.text = _title;
  }

  public void PopulateCards(List<Card> cards)
  {
    int cardCount = cards.Count;

    Cleanup();

    for (int i = 0; i < cardCount; i++)
    {
      var card = Instantiate(cards[i % cardCount]);
      var canvas = card.CardLayerController.Canvas;
      card.CardLayerController.ShowCardForUI();


      canvas.transform.SetParent(_gridLayoutGroup.transform);
      canvas.transform.localScale = Vector3.one;
      Destroy(card.gameObject);
    }
  }

  void Cleanup()
  {
    var children = _gridLayoutGroup.transform.GetComponentsInChildren<Canvas>();

    foreach (var child in children)
    {
      Destroy(child.gameObject);
    }
  }
}