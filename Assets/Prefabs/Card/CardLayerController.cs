using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLayerController : MonoBehaviour
{
  [SerializeField]
  private Canvas _canvas;
  [SerializeField]
  private SpriteRenderer[] _spriteRenderers;
  [SerializeField]
  private string _draggedSortingLayerName;
  private int _defaultSortingLayerID;


  void Start()
  {
    _defaultSortingLayerID = _canvas.sortingLayerID;
  }

  public void SetDraggedLayer()
  {
    _canvas.sortingLayerName = _draggedSortingLayerName;
    foreach (var spriteRenderer in _spriteRenderers)
    {
      spriteRenderer.sortingLayerName = _draggedSortingLayerName;
    }
  }

  public void SetDefaultLayer()
  {
    _canvas.sortingLayerID = _defaultSortingLayerID;
    foreach (var spriteRenderer in _spriteRenderers)
    {
      spriteRenderer.sortingLayerID = _defaultSortingLayerID;
    }
  }
}
