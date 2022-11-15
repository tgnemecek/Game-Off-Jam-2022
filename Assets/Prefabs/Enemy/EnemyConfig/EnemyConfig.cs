using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig_", menuName = "ScriptableObjects/EnemyConfig", order = 3)]
public class EnemyConfig : ScriptableObject
{
  public float MovementSpeed = 1f;
}