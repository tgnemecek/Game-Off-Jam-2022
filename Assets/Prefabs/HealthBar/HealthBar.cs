using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField]
  RectTransform _group;
  [SerializeField]
  RectTransform _hpBarForeground;
  [SerializeField]
  Color _hpBarDangerColor;
  [SerializeField]
  float _offsetY;

  Camera _camera;
  Transform _target;
  Image _hpBarImage;
  Color _baseHpBarColor;
  int _maxHP;
  int _hp;
  bool _alwaysShow = false;

  public void Initialize(Transform target, int maxHP, bool alwaysShow)
  {
    _camera = Camera.main;
    _target = target;
    _maxHP = maxHP;
    _hp = _maxHP;
    _hpBarImage = _hpBarForeground.GetComponent<Image>();
    _baseHpBarColor = _hpBarImage.color;
    _alwaysShow = alwaysShow;
    _group.gameObject.SetActive(_alwaysShow);
  }

  void FixedUpdate()
  {
    var screenPos = _camera.WorldToScreenPoint(_target.position);
    _group.transform.position = new Vector3(
        screenPos.x,
        screenPos.y + _offsetY,
        screenPos.z
    );
  }

  public void UpdateHealth(int hp)
  {
    _hp = hp;

    _group.gameObject.SetActive(_hp < _maxHP);

    float right = _maxHP - _hp;
    _hpBarForeground.offsetMax = new Vector2(-right, _hpBarForeground.offsetMax.y);
    UpdateColor();
  }

  void UpdateColor()
  {
    if (_hp <= _maxHP / 2)
    {
      _hpBarImage.color = _hpBarDangerColor;
    }
    else
    {
      _hpBarImage.color = _baseHpBarColor;
    }
  }
}
