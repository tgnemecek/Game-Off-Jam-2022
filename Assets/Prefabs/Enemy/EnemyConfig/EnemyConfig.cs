using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig_", menuName = "ScriptableObjects/EnemyConfig", order = 3)]
public class EnemyConfig : ScriptableObject
{
  public float MovementSpeed = 1f;
  public float StopDistanceFromTarget = .5f;
  [Range(0.1f, 10f)]
  public float AttackSpeed = 1f;
  [Range(0f, 90f)]
  public float WalkRotationAmount = 5f;
  public float WalkRotationSpeed = 1f;
  public float AttackedShrinkScale = 0.85f;
  public float AttackedRotationMultiplier = 6f;
  public float DeathDuration = 1f;
}