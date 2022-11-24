using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCost : MonoBehaviour
{
  [SerializeField]
  private LayoutGroup _layoutGroup;
  [SerializeField]
  private ResourceDisplay _displayPrefab;

  private List<ResourceDisplay> _displays = new List<ResourceDisplay>();

  public void SetCost(List<Resource> cost)
  {
    ClearList();

    foreach (var resource in cost)
    {
      if (resource.Amount > 0)
      {
        var display = Instantiate<ResourceDisplay>(_displayPrefab, _layoutGroup.transform);
        display.SetResource(resource);
      }
    }
  }

  void ClearList()
  {
    foreach (var display in _displays)
    {
      Destroy(display.gameObject);
    }
    _displays.Clear();
  }
}
