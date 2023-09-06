using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour,Enemy
{

    public NavMeshAgent navMeshAgent;
    public Transform player;
    public GameObject playerObject;
    public Animation enemyAnimator;
    public AudioSource hitSound, deathSound, attackAudio;
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
    public float sightRange;
    public float sightAngle,peripheralAngle, attackAngle;
    public bool playerInSightRange, playerInAttackRange;
    public bool isInCombat,isInvestigating;

    public string idleAnim;
    public string walkAnim;
    public string deathAnim;
    public string[] attackAnims;
    public int[] attackRange;
    public int[] attackDamage;
    public float [] attackDuration;
    public int attackId = 0;
    public bool attackSet = false;
    
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
            if (!attackSet)
            {
                attackId = UnityEngine.Random.Range(0, attackAnims.Length);
                attackSet = true;
            }
            if (!isInCombat)
            {
                playerInSightRange = IsInRange(player, sightAngle, sightRange) || Physics.CheckSphere(transform.position, attackRange[attackId], whatIsPlayer);
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
            playerInAttackRange = IsInRange(player, attackAngle, attackRange[attackId]);
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
                AttackPlayer(attackId);
            }
        }
    }
    IEnumerator InvestigatePlayer()
    {
        enemyAnimator.Play(idleAnim);
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
            enemyAnimator.Play(walkAnim);
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
        enemyAnimator.Play(walkAnim);
        navMeshAgent.SetDestination(player.position);
    }
    private void AttackPlayer(int id)
    {
        //stop movement
        navMeshAgent.SetDestination(transform.position);   
        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            coroutine = DelayAttack(id);
            StartCoroutine(coroutine);
        }
    }
    IEnumerator DelayAttack(int id)
    {
        enemyAnimator.Play(idleAnim);
        yield return new WaitForSeconds(.2f);
        attackAudio.Play();
        enemyAnimator.Play(attackAnims[id]);
        yield return new WaitForSeconds(attackDuration[id]/10f);
        if (IsInRange(player, attackAngle, attackRange[id] + 1f))
        {
            playerObject.GetComponent<PlayerStats>().TakeDamage(attackDamage[id]);
        }
        yield return new WaitForSeconds((attackDuration[id] * 9) / 10f);
        enemyAnimator.Play(idleAnim);
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;
        attackSet = false;
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
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
            enemyAnimator.Play(deathAnim);
            if (coroutine != null) StopCoroutine(coroutine);
            yield return new WaitForSeconds(6f);
            Destroy(gameObject);
        }
    }
}
