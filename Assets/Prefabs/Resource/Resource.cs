using UnityEngine;
using System;

public abstract class Resource
{
  protected Sprite _sprite;
  protected string _name = "";
  protected int _amount = 0;

  public ResourceTypes Type { get; set; }

  public Sprite Sprite
  {
    get
    {
      if (_sprite == null)
      {
        _sprite = Resources.Load<Sprite>("Card/Resource/" + _name);
      }
      return _sprite;
    }
  }

  public string Name => _name;
  public int Amount => _amount;

  private void SetAmount(int amount) => _amount = amount;

  private void ModifyAmount(int amount) => _amount += amount;

  private void IncrementAmount(int step = 1) => _amount += step;

  private void DecrementAmount(int step = -1) => _amount += step;

  public int GainResource(int amount)
  {
    this.ModifyAmount(Math.Abs(amount));
    return this._amount;
  }

  public int SpendResource(int amount)
  {
    this.ModifyAmount(-Math.Abs(amount));
    return this._amount;
  }
}