using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public enum ResourceTypes
{
  Wood = 0,
  Fish = 10,
  Gold = 20,
}

public class ResourcesManager : MonoBehaviour
{
  private static ResourcesManager _instance;

  public static ResourcesManager Instance { get { return _instance; } }

  [SerializeField]
  private int _initialWoodAmount = 0;
  [SerializeField]
  private int _initialFishAmount = 0;
  [SerializeField]
  private int _initialGoldAmount = 0;
  [SerializeField]
  private TextMeshProUGUI _woodText;
  [SerializeField]
  private TextMeshProUGUI _stoneText;
  [SerializeField]
  private TextMeshProUGUI _goldText;
  [SerializeField]
  private TextMeshProUGUI _fishText;

  public ResourcesDictionary _resourcesDictionary;

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
    _resourcesDictionary = new ResourcesDictionary(this._initialWoodAmount, this._initialFishAmount, this._initialGoldAmount);
    UpdateText();
  }

  public void Gain(int amount, ResourceTypes type)
  {
    if (amount <= 0) return;

    if (Enum.IsDefined(typeof(ResourceTypes), type))
    {
      _resourcesDictionary.getResource(type).GainResource(amount);

      UpdateText();
    }

  }
  public bool TryConsume(ResourcesDictionary cost)
  {
    foreach (var entry in cost.getValues())
    {
      if (!CanConsume(entry.Value))
      {
        return false;
      }
    }

    foreach (var entry in cost.getValues())
    {
      _resourcesDictionary.getResource(entry.Value.Type).SpendResource(entry.Value.Amount);
    }

    UpdateText();
    return true;
  }
  private bool CanConsume(Resource resource)
  {
    return resource.Amount <= _resourcesDictionary.getResource(resource.Type).Amount;
  }

  void UpdateText()
  {

    foreach (var entry in _resourcesDictionary.getValues())
    {
      string str = "x";

      TextMeshProUGUI textMesh = _woodText;
      string key = entry.Value.Name.ToString();
      if (key == "Wood") textMesh = _woodText;
      if (key == "Stone") textMesh = _stoneText;
      if (key == "Gold") textMesh = _goldText;
      if (key == "Fish") textMesh = _fishText;

      str += entry.Value.Amount.ToString();
      textMesh.text = str;
    }
  }
}
