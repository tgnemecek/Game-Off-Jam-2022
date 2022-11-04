using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;


public class ResourceCostDictionary : Dictionary<Resource, int>
{
  public ResourceCostDictionary() : base() { }
  public ResourceCostDictionary(Dictionary<Resource, int> dict) : base(dict) { }
}

public class ResourcesManager : MonoBehaviour
{
  private static ResourcesManager _instance;

  public static ResourcesManager Instance { get { return _instance; } }

  [SerializeField]
  private TextMeshProUGUI _resourceText;
  private ResourceCostDictionary _resources = new ResourceCostDictionary();

  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }
  }

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
  public bool TryConsume(ResourceCostDictionary cost)
  {
    ResourceCostDictionary newRes = new ResourceCostDictionary(_resources);

    foreach (Resource resource in Enum.GetValues(typeof(Resource)))
    {
      int amount = 0;
      if (cost.TryGetValue(resource, out amount))
      {
        if (!TryConsume(resource, amount))
        {
          return false;
        }
        newRes[resource] -= amount;
      }
    }
    _resources = newRes;
    UpdateText();
    return true;
  }
  private bool TryConsume(Resource resource, int cost)
  {
    if (cost > 0) return false;

    int currentAmount = _resources[resource];
    int finalAmount = currentAmount + cost;

    return finalAmount >= 0;
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
