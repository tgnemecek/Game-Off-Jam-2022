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

  void OnTriggerEnter(Collider collider)
  {
    if (collider.CompareTag("Card"))
    {
      _overlappingColliders.Add(collider);
    }
  }
  void OnTriggerExit(Collider collider)
  {
    if (collider.CompareTag("Card"))
    {
      _overlappingColliders.Remove(collider);
    }
  }
}
