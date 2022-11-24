using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class ResourcesManager : MonoBehaviour
{
  private static ResourcesManager _instance;

  public static ResourcesManager Instance { get { return _instance; } }

  [SerializeField]
  private int _initialResourceAmount = 0;
  [SerializeField]
  private TextMeshProUGUI _woodText;
  [SerializeField]
  private TextMeshProUGUI _stoneText;
  [SerializeField]
  private TextMeshProUGUI _fishText;

  private List<Resource> _resources = new List<Resource>(); public List<Resource> Resources => _resources;

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
    _resources.Add(new Resource_Wood(_initialResourceAmount));
    _resources.Add(new Resource_Fish(_initialResourceAmount));
    _resources.Add(new Resource_Gold(_initialResourceAmount));
    UpdateText();
  }

  public void Gain(Resource resource)
  {
    var amount = resource.Amount;

    if (amount <= 0) return;

    var currentResource = _resources.Find((r) => r.Name == resource.Name);
    currentResource.IncrementAmount(amount);
    UpdateText();
  }
  public bool TryConsume(List<Resource> cost)
  {
    List<Resource> newList = new List<Resource>(_resources);

    for (int i = 0; i < cost.Count; i++)
    {
      var resourceCost = cost[i];

      if (!CanConsume(resourceCost))
      {
        return false;
      }
      newList[i].IncrementAmount(-resourceCost.Amount);
    }

    _resources = newList;
    UpdateText();
    return true;
  }
  private bool CanConsume(Resource resource)
  {
    var cost = resource.Amount;
    var currentResourceAmount = _resources.Find((r) => r.Name == resource.Name).Amount;

    return (cost <= currentResourceAmount);
  }

  void UpdateText()
  {

    foreach (var entry in _resources)
    {
      string str = "x";

      TextMeshProUGUI textMesh = _woodText;
      string key = entry.Name.ToString();
      if (key == "Wood") textMesh = _woodText;
      if (key == "Stone") textMesh = _stoneText;
      if (key == "Fish") textMesh = _fishText;

      str += entry.Amount.ToString();
      textMesh.text = str;
    }
  }
}
