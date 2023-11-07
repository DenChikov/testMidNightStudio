using UnityEngine;

public class GetDamage : MonoBehaviour
{
    [SerializeField] protected float hp;

    public virtual void  TakeDamage(float damage)
    {
        hp -= damage;
    }
}
