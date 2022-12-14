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
  public float CatchUpSpeedWhileDragging = .1f;
  public float CardBendSpeed = 1f;
  public float CardBendMaxRotation = 0f;
  public float CardBendSmoothness = 0f;
  public float DistanceToBoardWhenPlaced = .3f;
  public float MinDistanceFromCoreWhenPlaced = 3.2f;
  public float TimeToPlaceOnBoard = 1f;
  public float OnBoardHoverOutlineSize = 0f;
  public float ConsumeAnimationTime = 1f;
  public float ConsumeAnimationRotation = 90f;
  public float DeathDuration = 1f;
}