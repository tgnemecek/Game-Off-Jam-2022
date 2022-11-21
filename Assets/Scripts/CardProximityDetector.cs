using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProximityDetector : MonoBehaviour
{
  HashSet<Collider> _overlappingColliders = new HashSet<Collider>();

  public bool IsCloseToAnotherCard()
  {
    return _overlappingColliders.Count > 0;
  }

#nullable enable
  public Collider? GetClosestCollider()
  {
    if (_overlappingColliders.Count == 0) return null;

    List<Collider> list = new List<Collider>(_overlappingColliders);

    if (list.Count == 1) return list[0];

    Collider closer = list[0];
    float shortestDistance = 9999;

    foreach (var collider in list)
    {
      var distance = (transform.position - collider.transform.position).magnitude;
      if (distance < shortestDistance)
      {
        closer = collider;
        shortestDistance = distance;
      }
    }

    return closer;
  }
#nullable disable

  void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag(GameManager.Instance.GameConfig.CardTag))
    {
      _overlappingColliders.Add(collider);
    }
  }
  void OnTriggerExit(Collider collider)
  {
    if (collider.CompareTag(GameManager.Instance.GameConfig.CardTag))
    {
      _overlappingColliders.Remove(collider);
    }
  }
}
