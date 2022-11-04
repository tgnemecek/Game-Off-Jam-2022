using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private static PlayerController _instance;

  public static PlayerController Instance { get { return _instance; } }

  [SerializeField]
  SectionTrigger _lowerSectionTrigger;

  public bool IsHoveringOnLowerSection => _lowerSectionTrigger.IsHovering;


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
}
