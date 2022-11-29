using System;
using System.Collections.Generic;

public class ResourcesDictionary
{
  private Dictionary<ResourceTypes, Resource> _;

  public ResourcesDictionary(int woodAmount, int fishAmount, int goldAmount)
  {
    _ = new Dictionary<ResourceTypes, Resource>{
      { ResourceTypes.Wood, new Resource_Wood(woodAmount) },
      { ResourceTypes.Fish, new Resource_Fish(fishAmount) },
      { ResourceTypes.Gold, new Resource_Gold(goldAmount) }
    };
  }

  public Resource getResource(ResourceTypes type)
  {
    if (Enum.IsDefined(typeof(ResourceTypes), type))
    {
      return _[type];
    }
    throw new Exception();
  }


  public Dictionary<ResourceTypes, Resource> getValues() { return _; }
}