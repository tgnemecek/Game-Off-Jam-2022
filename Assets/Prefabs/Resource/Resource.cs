using UnityEngine;

public abstract class Resource
{
  protected Sprite _sprite;
  protected string _name = "";
  protected int _amount = 0;

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

  public void IncrementAmount(int amount) => _amount += amount;
}