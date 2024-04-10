using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public MonstersData enemyData;
    public GameObject detectionZone; // Zone de d�tection de d�placement
    public GameObject attackZone; // Zone de d�tection d'attaque

    private Transform player;
    private NavMeshAgent navMeshAgent;
    private float nextAttackTime;
    private bool playerInAttackRange;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = enemyData.speed;
        playerInAttackRange = false;
    }

    void Update()
    {
        // Si le joueur est dans la zone de d�tection de d�placement, se dirige vers le joueur

        if (detectionZone.GetComponent<Collider>().bounds.Contains(player.position))
        {
            navMeshAgent.SetDestination(player.position);
        }

        // Si le joueur est dans la zone d'attaque et le monstre peut attaquer
        if (attackZone.GetComponent<Collider>().bounds.Contains(player.position) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + enemyData.attackCooldown;
        }

        // Si le joueur n'est pas dans la zone d'attaque mais dans la zone de d�placement, se rapproche du joueur
        if (!playerInAttackRange && detectionZone.GetComponent<Collider>().bounds.Contains(player.position))
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre dans la zone de d�tection d'attaque
        if (other.CompareTag("Player") && other.gameObject == attackZone)
        {
            playerInAttackRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si le joueur quitte la zone de d�tection d'attaque
        if (other.CompareTag("Player") && other.gameObject == attackZone)
        {
            playerInAttackRange = false;
        }
    }

    void Attack()
    {
        GameManager.Instance.life -= enemyData.damage;
    }

    public void TakeDamage(int damage)
    {
        enemyData.health -= damage;
        if (enemyData.health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
