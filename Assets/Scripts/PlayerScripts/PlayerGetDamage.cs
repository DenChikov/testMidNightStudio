using System;

public class PlayerGetDamage : GetDamage
{
    public static event Action loseStatistic; //UIManager Subscribe
    private bool playerDie;
    private void Awake()
    {
        EnemysTrigger.damageEvent += TakeDamage;
    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (hp < 0 && playerDie == false)
        {
            loseStatistic?.Invoke();
            playerDie = true;
        }
    }
}
