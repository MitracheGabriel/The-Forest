using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour, Enemy
{

    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject playerObject;
    public Animation enemyAnimator;
    public AudioSource hitSound, deathSound, swingAudio;
    public GameObject walkAudio;
    public LayerMask whatIsGround,whatIsPlayer;

    public float health;
    public bool isAlive,isStationary;
    public int damage;
    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public float sightAngle,peripheralAngle, attackAngle;
    public bool playerInSightRange, playerInAttackRange;
    public bool isInCombat,isInvestigating;


    
    IEnumerator coroutine;
    void Awake()
    {
        player = GameObject.Find("FPSController").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

   
    void Update()
    {
        if (isAlive)
        {
            if (!isInCombat)
            {
                playerInSightRange = IsInRange(player, sightAngle, sightRange) || Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
                if (!playerInSightRange && IsInRange(player, peripheralAngle, sightRange))
                {
                    walkAudio.SetActive(false);
                    StartCoroutine(InvestigatePlayer());
                }
            }
            else
            {
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange * 5, whatIsPlayer);
            }
            playerInAttackRange = IsInRange(player, attackAngle, attackRange);
            if (!playerInSightRange && !playerInAttackRange && !alreadyAttacked)
            {
                isInCombat = false;
                if (!isInvestigating && !isStationary)
                {
                    walkAudio.SetActive(true);
                    Patrol();
                }
            }
            if (playerInSightRange && !playerInAttackRange && !alreadyAttacked)
            {
                walkAudio.SetActive(true);
                isInCombat = true;
                ChasePlayer();
            }
            if (playerInSightRange && playerInAttackRange)
            {
                walkAudio.SetActive(false);
                AttackPlayer();
            }
        }
    }
    IEnumerator InvestigatePlayer()
    {
        enemyAnimator.Play("Idle");
        isInvestigating = true;
        navMeshAgent.SetDestination(transform.position);
        walkPointSet = true;
        yield return new WaitForSeconds(5f);
        if(IsInRange(player, peripheralAngle, sightRange))
        {
            isInCombat = true;
            playerInSightRange = true; 
        }
        walkPointSet = false;
        isInvestigating = false;
    }
    bool IsInRange(Transform target, float viewAngle, float viewRange)
    {
        Vector3 toTarget = target.position - transform.position;
        if (Vector3.Angle(transform.forward, toTarget) <= viewAngle)
            if (Physics.Raycast(transform.position, toTarget, out RaycastHit hit, viewRange))
            {
                if (hit.transform == target)
                {
                    return true;
                }
            }
        return false;
    }
        private void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            navMeshAgent.SetDestination(walkPoint);
            enemyAnimator.Play("WalkForward");
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        enemyAnimator.Play("WalkForward");
        navMeshAgent.SetDestination(player.position);
        //transform.LookAt(player, new Vector3(player.position.x,gameObject.transform.position.y, player.position.z));
    }
    private void AttackPlayer()
    {
        //stop movement
        navMeshAgent.SetDestination(transform.position);
        //transform.LookAt(player, Vector3.up);
        
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            coroutine = DelayAttack();
            StartCoroutine(coroutine);
        }

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    IEnumerator DelayAttack()
    {
        enemyAnimator.Play("Idle");
        yield return new WaitForSeconds(.1f);
        swingAudio.Play();
        enemyAnimator.Play("MeeleeAttack_OneHanded");
        yield return new WaitForSeconds(.5f);
        if (IsInRange(player, attackAngle, attackRange + 1f))
        {
            playerObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
        yield return new WaitForSeconds(.5f);
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }
    public void TakeDamage(int damage)
    {
        hitSound.Play();
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(DestroyEnemy());
        }
    }
    IEnumerator DestroyEnemy()
    {
        if (isAlive)
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            deathSound.Play();
            isAlive = false;
            navMeshAgent.SetDestination(transform.position);
            enemyAnimator.Play("Death");
            if (coroutine != null) StopCoroutine(coroutine);
            yield return new WaitForSeconds(2.5f);
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);  
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
