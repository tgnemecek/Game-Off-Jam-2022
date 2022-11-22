using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;


public class ResourceDictionary : Dictionary<Resource, int>
{
  public ResourceDictionary() : base() { }
  public ResourceDictionary(Dictionary<Resource, int> dict) : base(dict) { }
}

public class ResourcesManager : MonoBehaviour
{
  private static ResourcesManager _instance;

  public static ResourcesManager Instance { get { return _instance; } }

  [SerializeField]
  private TextMeshProUGUI _woodText;
  [SerializeField]
  private TextMeshProUGUI _stoneText;
  [SerializeField]
  private TextMeshProUGUI _fishText;
  private ResourceDictionary _resources = new ResourceDictionary();

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
  public bool TryConsume(ResourceDictionary cost)
  {
    ResourceDictionary newRes = new ResourceDictionary(_resources);

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

    foreach (var entry in _resources)
    {
      string str = "x";

      TextMeshProUGUI textMesh = _woodText;
      string key = entry.Key.ToString();
      if (key == "Wood") textMesh = _woodText;
      if (key == "Stone") textMesh = _stoneText;
      if (key == "Fish") textMesh = _fishText;

      str += entry.Value.ToString();
      textMesh.text = str;
    }
  }
}
