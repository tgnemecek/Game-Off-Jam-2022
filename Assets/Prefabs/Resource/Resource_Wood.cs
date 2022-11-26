using System.Collections;
using System.Collections.Generic;

public class Resource_Wood : Resource
{
  public Resource_Wood(int amount = 0)
  {
    this.Type = ResourceTypes.Wood;
    _amount = amount;
    _name = "Wood";
  }
}