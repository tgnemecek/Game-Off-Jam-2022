using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Wood : Card
{
  public override void Play()
  {
    _resourcesManager.Gain(Resource.Wood, 1);
  }
  public override void EndOfTurn() { }
}
