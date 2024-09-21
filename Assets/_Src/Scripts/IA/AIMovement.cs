using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMoviment : MonoBehaviour
{
    private NavMeshAgent nav;
    [Header("Player Info")]
    public Transform player;

    [Header("Enemy Info")]
    public float AttackRange;
    public float AttackSpeed;
    public float[ ] AttackDamage;
    public float currentAttackCooldown;
    public bool canAttack;


    void Start()
    {
        nav = GetComponent <NavMeshAgent>();
        nav.stoppingDistance = AttackRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        
        Chase( );
        if(Vector3.Distance(transform.position, player.position) < AttackRange)
        
        if (canAttack)
        {
            Attack( );
        }
        else
        {
            currentAttackCooldown -= Time.deltaTime;

            if(currentAttackCooldown <0)
            {
                canAttack = true;
                currentAttackCooldown = AttackSpeed;
            }
        }

    }

    void Chase ( )
    {
        nav.SetDestination(player.position);
    }

    void Attack( )
    {
        canAttack = false;
        player.GetComponent<IDamageable>().TakeDamage(UnityEngine.Random.Range(1,50));
    }
}
