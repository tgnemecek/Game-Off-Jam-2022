using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour, IHitable
{
  [SerializeField]
  int _maxHP;
  [SerializeField]
  RectTransform _hpBarForeground;
  [SerializeField]
  Collider _collider;
  int _hp;

  void Start()
  {
    _hp = _maxHP;
  }

  public void ReceiveDamage(int damage)
  {
    _hp -= damage;

    if (_hp <= 0)
    {
      _hp = 0;
      GameManager.Instance.GameOver();
    }
    float right = _maxHP - _hp;
    _hpBarForeground.offsetMax = new Vector2(-right, _hpBarForeground.offsetMax.y);
  }

  public void StartBattle(IHitable hitable) { }

  public Collider GetCollider() => _collider;
  public Transform GetTransform() => transform;
}
