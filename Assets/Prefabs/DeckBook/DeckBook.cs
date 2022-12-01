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

  private List<Card> _cards = new List<Card>(); public List<Card> Cards => _cards;

  void Start()
  {
    _textMesh.text = _title;
  }

  public void AddCard(Card card)
  {
    _cards.Insert(0, card);

    Cleanup();
    PopulateCards();
  }

  public void SetCards(List<Card> cards)
  {
    _cards = new List<Card>(cards);

    Cleanup();
    PopulateCards();
  }

  void PopulateCards()
  {
    int cardCount = _cards.Count;
    for (int i = 0; i < cardCount; i++)
    {
      var card = _cards[i % cardCount];
      var copiedCard = Instantiate(card);
      copiedCard.Initialize(CardStateEnum.InPile);
      copiedCard.CardLayerController.ShowCardForUI();

      var canvas = copiedCard.CardLayerController.Canvas;
      canvas.transform.SetParent(_gridLayoutGroup.transform);
      canvas.transform.localScale = Vector3.one;
      Destroy(copiedCard.gameObject);
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

  void OnEnable()
  {
    PlayerController.Instance.CanInteractWithCards = false;
  }

  void OnDisable()
  {
    PlayerController.Instance.CanInteractWithCards = true;
  }
}