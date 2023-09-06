using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public LayerMask mask;
    public int dmg;
    private bool canDmg;
    public float attackDuriation;
    private float timeSinceAttack;
    private GameObject meleeAttack;

    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        if (timeSinceAttack > attackDuriation)
        {
            canDmg = false;
        } 
    }

    public void Attack()
    {
        canDmg = true;
        timeSinceAttack = 0;
    }

    public void StopAttack()
    {
        canDmg = false;
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (canDmg)
        {
            if (mask == (mask | (1 << other.gameObject.layer)))
            {              
                EnemyAI enemy = other.GetComponentInParent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.TakeDamage(dmg);
                    canDmg = false;
                }
            }
        }

    }
}
