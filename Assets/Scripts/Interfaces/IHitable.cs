using UnityEngine;

public interface IHitable
{
  public void ReceiveDamage(int damage);
  public bool isDead();
  public Collider GetCollider();
  public Transform GetTransform();
}