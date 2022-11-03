using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
  [SerializeField]
  private TextMeshProUGUI _resourceText;
  private Dictionary<Resource, int> _resources = new Dictionary<Resource, int>();

  void Start()
  {
    foreach (Resource resource in Enum.GetValues(typeof(Resource)))
    {
      _resources.Add(resource, 0);
    }
    UpdateText();
  }

  public void Gain(Resource resource, int amount)
  {
    if (amount < 0) return;

    int currentAmount = _resources[resource];
    _resources[resource] = currentAmount + amount;
    UpdateText();
  }
  public bool TryConsume(Resource resource, int amount)
  {
    if (amount > 0) return false;

    int currentAmount = _resources[resource];
    int finalAmount = currentAmount + amount;

    if (finalAmount < 0) return false;

    _resources[resource] = currentAmount - amount;
    UpdateText();
    return true;
  }
  void UpdateText()
  {
    string str = "";

    foreach (var entry in _resources)
    {
      str += entry.Key + ": " + entry.Value.ToString() + "\n";
    }
    _resourceText.text = str;
  }
}
