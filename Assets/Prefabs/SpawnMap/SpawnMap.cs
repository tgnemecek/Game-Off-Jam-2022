using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
  List<Transform> _spawnPoints; public List<Transform> SpawnPoints => _spawnPoints;

  void Awake()
  {
    _spawnPoints = new List<Transform>(GetComponentsInChildren<Transform>());
    _spawnPoints.Sort((Transform a, Transform b) =>
    {
      return Mathf.RoundToInt(a.position.x - b.position.x);
    });
  }
}
