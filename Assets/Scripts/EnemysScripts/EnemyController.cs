using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static event Action winStatistic;
    [SerializeField] private List<EnemysGetDamage> enemysCount;
    int allEnemies;
    private void Awake()
    {
        allEnemies = enemysCount.Count;
        foreach (var enemy in enemysCount)
        {
            enemy.EnemyDestroy += EnemyDie;
        }
    }
    private void EnemyDie()
    {
        allEnemies = allEnemies - 1;
        if (allEnemies <= 0)
        {
            winStatistic?.Invoke();
        }
    }
}
