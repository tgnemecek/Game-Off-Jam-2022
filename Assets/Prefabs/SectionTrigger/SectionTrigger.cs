using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
  bool _isHovering = false; public bool IsHovering => _isHovering;

  void OnMouseEnter() => _isHovering = true;
  void OnMouseExit() => _isHovering = false;
}
