using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public GameObject meleeAttack;
    
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Invoke(nameof(Attack), .5f);
        }
    }
    void Attack()
    {
        StartCoroutine(AttackSequence());
    }
    IEnumerator AttackSequence()
    {
        meleeAttack.SetActive(true);
        meleeAttack.GetComponent<MeleeAttack>().Attack();
        GetComponent<Animation>().Play("AttackAnimation");
        yield return new WaitForSeconds(.5f);
        meleeAttack.SetActive(false);
    }
}
