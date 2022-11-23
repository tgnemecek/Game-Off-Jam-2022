using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceDisplay : MonoBehaviour
{
  [SerializeField]
  private Image _icon;
  [SerializeField]
  private TextMeshProUGUI _text;

  public void SetResource(Resource resource)
  {
    _icon.sprite = resource.GetSprite();
    _text.text = "x" + resource.Amount;
  }
}
