using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
  [SerializeField]
  private Board _board;
  [SerializeField]
  private Collider _spawnArea;

  [SerializeField]
  private List<Enemy> _nextWave = new List<Enemy>();
  private List<Enemy> _currentWave = new List<Enemy>();

  public void SpawnNextWave()
  {
    foreach (var e in _nextWave)
    {
      Enemy enemy = Instantiate(e, _spawnArea.transform.position, Quaternion.identity, _spawnArea.transform);
      enemy.transform.localPosition = GetRandomPositionInSpawnArea();
      enemy.transform.localRotation = Quaternion.Euler(90, 0, 0);

      int randomIndex = UnityEngine.Random.Range(0, _board.Cards.Count - 1);
      var randomCard = _board.Cards[randomIndex];
      enemy.Target = randomCard;
      _currentWave.Add(enemy);
    }
  }
  public void ClearWave()
  {
    foreach (var enemy in _currentWave)
    {
      Destroy(enemy.gameObject);
    }
    _currentWave.Clear();
  }
  private Vector3 GetRandomPositionInSpawnArea()
  {
    Vector3 extents = _spawnArea.transform.InverseTransformVector(_spawnArea.bounds.extents);

    return new Vector3(
        Random.Range(-extents.x, extents.x),
        Random.Range(-extents.y, extents.y),
        0f
    );
  }
}
