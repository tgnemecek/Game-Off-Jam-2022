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
  private SpriteRenderer _backSprite;
  [SerializeField]
  private SpriteRenderer _shadowSprite;
  [SerializeField]
  private SpriteRenderer _onHoverSprite;
  [SerializeField]
  private TextMeshProUGUI _nameText;
  [SerializeField]
  private CardCost _cardCost;
  private CardConfig _cardConfig;

  private int _defaultSortingLayerID;

  public void Initialize(string cardName, Sprite sprite, ResourcesDictionary resourcesDictionary, CardConfig cardConfig)
  {
    _cardConfig = cardConfig;
    _nameText.text = cardName;
    _nameText.fontSize = _cardConfig.FontSizeInHand;
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
    _backSprite.sortingLayerName = _drawPileSortingLayerName;
    _onHoverSprite.sortingLayerName = _drawPileSortingLayerName;
  }

  public void SetOnBoardLayer()
  {
    _canvas.sortingLayerName = _draggedSortingLayerName;
    _backSprite.sortingLayerName = _draggedSortingLayerName;
    _onHoverSprite.sortingLayerName = _draggedSortingLayerName;
  }

  public void SetCloseUpLayer()
  {
    _canvas.sortingLayerName = _closeupSortingLayerName;
    _backSprite.sortingLayerName = _closeupSortingLayerName;
    _onHoverSprite.sortingLayerName = _closeupSortingLayerName;
  }

  public void SetDefaultLayer()
  {
    _canvas.sortingLayerID = _defaultSortingLayerID;
    _backSprite.sortingLayerID = _defaultSortingLayerID;
    _onHoverSprite.sortingLayerID = _defaultSortingLayerID;
  }

  public void ShowCardBack()
  {
    _backSprite.gameObject.SetActive(true);
    _canvas.gameObject.SetActive(false);
  }

  public void ShowCardFront()
  {
    _backSprite.gameObject.SetActive(false);
    _canvas.gameObject.SetActive(true);
  }

  public void ShowCardForUI()
  {
    _canvas.transform.rotation = Quaternion.identity;
    ShowCardFront();
  }

  public void ToggleShadow(bool enabled)
  {
    _shadowSprite.gameObject.SetActive(enabled);
  }

  public void ToggleHoverOutline(bool enabled)
  {
    if (enabled)
    {
      float offsetSize = _cardConfig.OnBoardHoverOutlineSize;

      float x = _backSprite.transform.localScale.x + offsetSize;
      float y = _backSprite.transform.localScale.y + offsetSize;

      _onHoverSprite.transform.localScale = new Vector3(x, y, 1);
    }
    else
    {
      _onHoverSprite.transform.localScale = Vector3.one;
    }
  }
}
