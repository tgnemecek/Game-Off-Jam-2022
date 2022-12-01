using UnityEngine;

public interface IHitable
{
  public void ReceiveDamage(int damage);
  public bool CanBeTargeted();
  public Collider GetCollider();
  public Transform GetTransform();
}