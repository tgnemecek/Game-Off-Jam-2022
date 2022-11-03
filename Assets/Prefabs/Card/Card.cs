using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Card : MonoBehaviour
{
  [SerializeField]
  private string _name;
  [SerializeField]
  private int _woodCost = 0;
  [SerializeField]
  private int _stoneCost = 0;

  [SerializeField]
  private TextMeshProUGUI _nameText;

  protected ResourcesManager _resourcesManager;
  protected Hand _hand;
  private Dictionary<Resource, int> _cost = new Dictionary<Resource, int>();

  public void Initialize(ResourcesManager resourcesManager, Hand hand)
  {
    _cost.Add(Resource.Wood, _woodCost);
    _cost.Add(Resource.Stone, _stoneCost);
    _nameText.text = _name;
    _resourcesManager = resourcesManager;
    _hand = hand;
    enabled = true;
  }

  void Awake()
  {
    enabled = false;
    _nameText.gameObject.SetActive(false);
  }

  void Update()
  {
    CheckCardSide();
  }

  void CheckCardSide()
  {
    float absRotationY = Mathf.Abs(transform.rotation.eulerAngles.y);
    _nameText.gameObject.SetActive(absRotationY < 90);
  }

  public abstract void Play();
}