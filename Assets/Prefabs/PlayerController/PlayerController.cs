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
  private IPile _pilePointedTo;

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
    CastMouseRays();
    DetectHoverOnHand();
  }

  void CastMouseRays()
  {
    var (success, hit) = CastRayForLayerMask(GameManager.Instance.GameConfig.MouseHoverLayerMask);

    HandleCardHover(hit.collider);
    HandlePileHover(hit.collider);
  }

  void HandleCardHover(Collider collider)
  {
    Card card = collider?.GetComponent<Card>();
    CardPointedTo = card;
  }

  void HandlePileHover(Collider collider)
  {
    IPile pile = collider?.GetComponent<IPile>();
    if (pile != null)
    {
      if (_pilePointedTo != pile) _pilePointedTo?.MouseExit();
      pile.MouseEnter();
      _pilePointedTo = pile;
      return;
    }
    if (_pilePointedTo != null)
    {
      _pilePointedTo.MouseExit();
      _pilePointedTo = null;
    }
  }

  void DetectHoverOnHand()
  {
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