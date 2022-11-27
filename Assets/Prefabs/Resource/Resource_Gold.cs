using System.Collections;
using System.Collections.Generic;

public class Resource_Gold : Resource
{
  public Resource_Gold(int amount = 0)
  {
    this.Type = ResourceTypes.Gold;
    _amount = amount;
    _name = "Gold";
  }
}