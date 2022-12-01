using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  [SerializeField]
  Transform _group;
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
    PositionSelf();
  }

  public void UpdateHealth(int hp)
  {
    _hp = hp;

    _group.gameObject.SetActive(_hp < _maxHP && _hp > 0);

    float left = (float)_maxHP - (float)_hp;
    _hpBarForeground.offsetMin = new Vector2(left, _hpBarForeground.offsetMin.y);
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

  void FixedUpdate()
  {
    RotateSelf();
  }

  void PositionSelf()
  {
    transform.localPosition = new Vector3(
      0f,
      _offsetY,
      0f
    );
  }

  void RotateSelf()
  {
    var target = new Vector3(
      transform.position.x,
      Camera.main.transform.position.y,
      Camera.main.transform.position.z
    );

    transform.LookAt(target);
  }
}
