using UnityEngine;

public interface IHitable
{
  public void StartBattle(IHitable hitable);
  public void ReceiveDamage(int damage);
  public Collider GetCollider();
  public Transform GetTransform();
}