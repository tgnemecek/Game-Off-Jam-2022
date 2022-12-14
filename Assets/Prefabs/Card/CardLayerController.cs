using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardLayerController : MonoBehaviour
{
  [SerializeField]
  private Canvas _canvas; public Canvas Canvas => _canvas;
  [SerializeField]
  private string _drawPileSortingLayerName;
  [SerializeField]
  private string _draggedSortingLayerName;
  [SerializeField]
  private string _closeupSortingLayerName;
  [SerializeField]
  private Image _cardImage;
  [SerializeField]
  private SpriteRenderer _shadowSprite;
  [SerializeField]
  private SpriteRenderer _onHoverSprite;
  [SerializeField]
  private TextMeshProUGUI _nameText;

  [SerializeField]
  private TextMeshProUGUI _descriptionText;
  [SerializeField]
  private CardCost _cardCost;
  private CardConfig _cardConfig;

  private int _defaultSortingLayerID;

  public void Initialize(string cardName, Sprite sprite, string cardDescription, ResourcesDictionary resourcesDictionary, CardConfig cardConfig)
  {
    _cardConfig = cardConfig;
    _nameText.text = cardName;
    _descriptionText.text = cardDescription;
    _cardImage.sprite = sprite;
    _defaultSortingLayerID = _canvas.sortingLayerID;
    _cardCost.SetResourcesDictionary(resourcesDictionary);
  }

  public void SetCardImage(Sprite sprite)
  {
    _cardImage.sprite = sprite;
  }

  public void SetPileLayer()
  {
    _canvas.sortingLayerName = _drawPileSortingLayerName;
    _onHoverSprite.sortingLayerName = _drawPileSortingLayerName;
  }

  public void SetOnBoardLayer()
  {
    _canvas.sortingLayerName = _draggedSortingLayerName;
    _onHoverSprite.sortingLayerName = _draggedSortingLayerName;
  }

  public void SetCloseUpLayer()
  {
    _canvas.sortingLayerName = _closeupSortingLayerName;
    _onHoverSprite.sortingLayerName = _closeupSortingLayerName;
  }

  public void SetDefaultLayer()
  {
    _canvas.sortingLayerID = _defaultSortingLayerID;
    _onHoverSprite.sortingLayerID = _defaultSortingLayerID;
    ToggleHoverOutline(false);
  }

  public void ShowCardForUI()
  {
    _canvas.transform.rotation = Quaternion.identity;
  }

  public void ToggleShadow(bool enabled)
  {
    _shadowSprite.gameObject.SetActive(enabled);
  }

  public void ToggleHoverOutline(bool enabled)
  {
    _onHoverSprite.gameObject.SetActive(enabled);
  }
}
