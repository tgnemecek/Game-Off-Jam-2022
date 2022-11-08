using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBook : MonoBehaviour
{
  private bool _isVisible = false;

  // Start is called before the first frame update
  void Start()
  {
    Hide();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Trigger()
  {
    if (_isVisible)
    {
      Hide();
    }
    else
    {
      Show();
    }

  }

  public void Show()
  {
    this.enabled = true;
    this.gameObject.SetActive(true);
    _isVisible = true;
  }

  public void Hide()
  {
    this.enabled = false;
    this.gameObject.SetActive(false);
    _isVisible = false;
  }
}
