using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  [SerializeField]
  private Board _board;
  [SerializeField]
  private SpawnMap _spawnMap;
  [SerializeField]
  private List<Enemy> _nextWave = new List<Enemy>();
  private List<Enemy> _currentWave = new List<Enemy>();

  void Start()
  {
    _spawnMap = Instantiate(_spawnMap, _board.transform);
  }

  public void SpawnNextWave()
  {
    int spawnMapIndex = 0;
    var spawnPoints = _spawnMap.SpawnPoints;

    foreach (var e in _nextWave)
    {
      Enemy enemy = Instantiate(e, spawnPoints[spawnMapIndex].position, Quaternion.identity, transform);

      if (spawnMapIndex + 1 == spawnPoints.Count)
      {
        spawnMapIndex = 0;
      }
      else spawnMapIndex += 1;

      _currentWave.Add(enemy);
    }
  }


  public bool AreEnemiesStillAlive() => _currentWave.Count > 0;

  public void RegisterEnemyDeath(Enemy enemy)
  {
    _currentWave.Remove(enemy);
    if (_currentWave.Count == 0)
    {
      GameManager.Instance.OnWaveClear();
    }
  }
  public void DisableAllEnemies()
  {
    foreach (var enemy in _currentWave)
    {
      enemy.enabled = false;
    }
  }
  // private Vector3 GetRandomPositionInSpawnArea()
  // {
  //   Vector3 extents = _spawnArea.transform.InverseTransformVector(_spawnArea.bounds.extents);

  //   return new Vector3(
  //       Random.Range(-extents.x, extents.x),
  //       Random.Range(-extents.y, extents.y),
  //       0f
  //   );
  // }
}
