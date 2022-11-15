using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  [SerializeField]
  Collider _spawnArea;

  [SerializeField]
  List<Enemy> _nextWave = new List<Enemy>();

  void Start()
  {
    SpawnNextWave();
  }

  public void SpawnNextWave()
  {
    foreach (var e in _nextWave)
    {
      Enemy enemy = Instantiate(e, _spawnArea.transform.position, _spawnArea.transform.rotation, _spawnArea.transform);
      enemy.transform.localPosition = GetRandomPositionInSpawnArea();
    }
  }
  public Vector3 GetRandomPositionInSpawnArea()
  {
    Vector3 extents = _spawnArea.transform.InverseTransformVector(_spawnArea.bounds.extents);

    return new Vector3(
        Random.Range(-extents.x, extents.x),
        Random.Range(-extents.y, extents.y),
        0f
    );
  }
}
