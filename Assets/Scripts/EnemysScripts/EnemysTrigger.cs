using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemysTrigger : MonoBehaviour
{
    private float attackRange = 1.5f;
    private float attackDamage = 0.2f;
    private Transform player;
    private NavMeshAgent agent;
    private Animator npcAnimator;

    public static event Action<float> damageEvent;
    private void Start()
    {
        npcAnimator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(player.position);
            npcAnimator.SetFloat("npcSpeed", agent.velocity.magnitude);
            float distanceToAttackPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToAttackPlayer <= attackRange)
            {
                npcAnimator.SetTrigger("attack");
                //other.GetComponent<PlayerGetDamage>().TakeDamage(attackDamage);
                damageEvent?.Invoke(attackDamage); //PlayerGetDamage Subscribe
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        agent.SetDestination(transform.position);
    }
}
