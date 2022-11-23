using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Resource_", menuName = "ScriptableObjects/Resource", order = 4)]
public class Resource : ScriptableObject
{
  public string Name;
  [SerializeField]
  private string _spritePath;
  private Sprite _sprite;

  [HideInInspector]
  public int Amount = 0;
  public void SetAmount(int amount) => Amount = amount;
  public Sprite GetSprite() => _sprite;

  void Awake()
  {
    _sprite = AssetDatabase.LoadAssetAtPath<Sprite>(_spritePath);
  }
}