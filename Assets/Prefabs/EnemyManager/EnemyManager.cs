using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  [SerializeField]
  private Board _board;
  [SerializeField]
  private int _spawnPoolPoints;
  [SerializeField]
  private SpawnMap _spawnMap;
  private List<Enemy> _nextWave = new List<Enemy>();
  private List<Enemy> _currentWave = new List<Enemy>();
  [SerializeField]
  private List<Enemy> _enemyTypes = new List<Enemy>();

  private List<Action> _onEnemyKilled = new List<Action>(); public List<Action> OnEnemyKilled => _onEnemyKilled;

  void Start()
  {
    _spawnMap = Instantiate(_spawnMap, _board.transform);
  }

  public void SpawnNextWave()
  {
    int spawnMapIndex = 0;
    var spawnPoints = _spawnMap.SpawnPoints;

    GenerateWave();

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

    IncreasePoolSize();
  }

  private void GenerateWave()
  {
    _nextWave.Clear();
    int availablePoints = _spawnPoolPoints;
    Enemy enemy = GrabEnemyFromPool(availablePoints);

    while (enemy != null)
    {
      _nextWave.Add(enemy);
      availablePoints -= Mathf.Max(enemy.EnemyConfig.PoolCost, 1);
      enemy = GrabEnemyFromPool(availablePoints);
    }
  }

  private Enemy GrabEnemyFromPool(int availablePoints)
  {
    if (availablePoints == 0) return null;

    List<Enemy> availableEnemies = _enemyTypes.FindAll(e => e.EnemyConfig.PoolCost <= availablePoints);
    if (availableEnemies.Count == 0) return null;

    int randomIndex = (int)Mathf.Min(Mathf.Round(UnityEngine.Random.Range(0, availableEnemies.Count)), availableEnemies.Count - 1);
    return availableEnemies[randomIndex];
  }

  private void IncreasePoolSize()
  {
    _spawnPoolPoints += 15;
  }


  public bool AreEnemiesStillAlive() => _currentWave.Count > 0;

  public void RegisterEnemyDeath(Enemy enemy)
  {
    _currentWave.Remove(enemy);

    foreach (var Callback in _onEnemyKilled)
    {
      Callback();
    }


    if (_currentWave.Count == 0)
    {
      OnWaveClear();
    }
  }

  public void OnWaveClear()
  {
    _onEnemyKilled = new List<Action>();
    GameManager.Instance.OnWaveClear();
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
