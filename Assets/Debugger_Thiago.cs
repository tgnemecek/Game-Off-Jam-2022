using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger_Thiago : MonoBehaviour
{
  public Hand Hand;
  public Card Card;

  void Awake()
  {
    Hand = FindObjectOfType<Hand>();
  }

  void Start()
  {
    if (!Card.gameObject.scene.IsValid())
    {
      Card = Instantiate(Card);
    }
    Card.Draw(Hand);
  }
}
