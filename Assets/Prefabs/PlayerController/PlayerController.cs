using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private static PlayerController _instance;

  public static PlayerController Instance { get { return _instance; } }

  private Camera _camera;
  [HideInInspector]
  public Card CardPointedTo;
  [HideInInspector]
  public Card CardBeingDragged;

  public bool IsDraggingCard => CardBeingDragged != null;
  private bool _isHoveringOnHand = false; public bool IsHoveringOnHand => _isHoveringOnHand;

  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }
  }

  void Start()
  {
    _camera = Camera.main;
  }

  void FixedUpdate()
  {
    CastRayForCards();
    CastRayForHand();
  }

  void CastRayForCards()
  {
    if (!GameManager.Instance.IsCardInteractionActive) return;

    if (IsDraggingCard)
    {
      CardPointedTo = CardBeingDragged;
      return;
    }

    var (success, hit) = CastRayForLayerMask(GameManager.Instance.GameConfig.CardLayerMask);

    if (success)
    {
      Card card;
      if (hit.collider.TryGetComponent<Card>(out card))
      {
        if (card == CardPointedTo) return;
        CardPointedTo = card;
      }
    }
    else if (CardPointedTo != null)
    {
      CardPointedTo = null;
    }
  }

  void CastRayForHand()
  {
    if (!GameManager.Instance.IsCardInteractionActive) return;

    var (success, hit) = CastRayForLayerMask(GameManager.Instance.GameConfig.HandLayerMask);
    _isHoveringOnHand = success;
  }

  (bool, RaycastHit) CastRayForLayerMask(LayerMask mask)
  {
    RaycastHit hit;
    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
    bool success = Physics.Raycast(ray, out hit, 99f, mask);
    return (success, hit);
  }
}