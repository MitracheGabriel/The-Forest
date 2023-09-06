using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ActionItem
{
    public float timeBetweenAttacks;

    IEnumerator Attack()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Play("AttackAnimation"); 
        GetComponentInParent<Player>().Attack();
        yield return new WaitForSeconds(.5f);
        Player.isBusy = false;
    }
    public override void DoAction()
    {
        Player.isBusy = true;
        StartCoroutine(Attack());
    }
}
