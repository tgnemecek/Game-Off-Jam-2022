using System.Collections;
using System.Collections.Generic;

public class Resource_Fish : Resource
{
  public Resource_Fish(int amount = 0)
  {
    this.Type = ResourceTypes.Fish;
    _amount = amount;
    _name = "Fish";
  }
}