using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProximityDetector : MonoBehaviour
{
  private Card _card;
  HashSet<Collider> _overlappingColliders = new HashSet<Collider>();

  public void Initialize(Card card)
  {
    _card = card;
  }

  public bool IsCloseToAnotherCard()
  {
    return _overlappingColliders.Count > 0;
  }

#nullable enable
  public Collider? GetClosestCollider()
  {
    if (_overlappingColliders.Count == 0) return null;

    List<Collider> list = new List<Collider>(_overlappingColliders);

    Collider? closer = null;
    float shortestDistance = 9999;

    foreach (var collider in list)
    {
      if (!collider.enabled)
      {
        continue;
      }
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
    if (!collider.enabled)
    {
      _overlappingColliders.Remove(collider);
      return;
    }

    if (collider.CompareTag(GameManager.Instance.GameConfig.CardTag))
    {
      Card otherCard;
      if (collider.TryGetComponent<Card>(out otherCard))
      {
        if (_card != otherCard)
        {
          _overlappingColliders.Add(collider);
        }
      }
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
