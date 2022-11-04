using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardConfig_", menuName = "ScriptableObjects/CardConfig", order = 2)]
public class CardConfig : ScriptableObject
{
  public float ScaleOnHover = 1f;
  public float ScaleOnHoverTime = 1f;
  public float OffsetYOnHover = 0f;
  public float MovementToHandTime = 1f;
  public float CatchUpTimeWhileDragging = .1f;
  public float CardBendSpeed = 1f;
  public float CardBendMaxRotation = 0f;
  public float CardBendSmoothness = 0f;
}