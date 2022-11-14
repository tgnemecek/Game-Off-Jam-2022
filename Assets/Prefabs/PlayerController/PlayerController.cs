using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private static PlayerController _instance;

  public static PlayerController Instance { get { return _instance; } }

  [SerializeField]
  SectionTrigger _lowerSectionTrigger;
  [SerializeField]
  LayerMask _cardLayerMask;
  private Camera _camera;

  public bool IsHoveringOnLowerSection => _lowerSectionTrigger.IsHovering;
  [HideInInspector]
  public Card CardPointedTo;
  private bool _isDraggingCard = false; public bool IsDraggingCard { get { return _isDraggingCard; } set { _isDraggingCard = value; } }

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
    RaycastHit hit;
    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

    if (Physics.Raycast(ray, out hit, 99f, _cardLayerMask))
    {
      Card card;
      if (hit.collider.TryGetComponent<Card>(out card))
      {
        if (card == CardPointedTo) return;
        if (CardPointedTo != null) CardPointedTo.MouseExit();

        CardPointedTo = card;
        CardPointedTo.MouseEnter();
      }
    }
    else if (CardPointedTo != null)
    {
      CardPointedTo.MouseExit();
      CardPointedTo = null;
    }
  }
}