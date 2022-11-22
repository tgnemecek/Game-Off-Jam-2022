using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig_", menuName = "ScriptableObjects/GameConfig", order = 2)]
public class GameConfig : ScriptableObject
{
  public float DelayBetweenEndOfTurnTasks = .2f;
  public float EnemyTurnDuration = 10f;
  [Header("Layer Masks & Tags")]
  public LayerMask CardLayerMask;
  public LayerMask HandLayerMask;
  public LayerMask BoardLayerMask;
  public LayerMask PileLayerMask;
  public string CardTag;
}