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
  private string _draggedSortingLayerName;
  [SerializeField]
  private Image _cardPanel;
  [SerializeField]
  private SpriteRenderer _backSprite;
  [SerializeField]
  private SpriteRenderer _onHoverSprite;
  [SerializeField]
  private TextMeshProUGUI _nameText;
  private CardConfig _cardConfig;

  private int _defaultSortingLayerID;

  public void Initialize(string cardName, CardConfig cardConfig)
  {
    _nameText.text = cardName;
    _cardConfig = cardConfig;
    _defaultSortingLayerID = _canvas.sortingLayerID;
  }

  public void SetDraggedLayer()
  {
    _canvas.sortingLayerName = _draggedSortingLayerName;
  }

  public void SetDefaultLayer()
  {
    _canvas.sortingLayerID = _defaultSortingLayerID;
  }

  public void ShowCardBack()
  {
    _backSprite.gameObject.SetActive(true);
    _canvas.gameObject.SetActive(false);
    _nameText.fontSize = _cardConfig.FontSizeInHand;
  }

  public void ShowCardFront()
  {
    _backSprite.gameObject.SetActive(false);
    _canvas.gameObject.SetActive(true);
    _nameText.fontSize = _cardConfig.FontSizeInHand;
  }

  public void ShowCardForUI()
  {
    ShowCardFront();
    _nameText.fontSize = _cardConfig.FontSizeInDeckBook;
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
