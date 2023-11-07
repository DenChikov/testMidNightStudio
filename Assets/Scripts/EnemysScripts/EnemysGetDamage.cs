using System;

public class EnemysGetDamage : GetDamage
{
    public  event Action EnemyDestroy;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (hp <= 0)
        {
            EnemyDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}
