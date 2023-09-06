using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Gun : ActionItem
{
    public float timeBetweenAttacks;
    public float reloadTime;
    public int magazineSize;
    public int bulletsInMagazine;
    public AudioSource shootAudio;
    public AudioSource misfireAudio;
    public AudioSource reloadAudio;
    public ItemObject bulletItem;
    public int bullletCount = 0;
    public InventoryObject inventory;
    public InventorySlot bulletSlot;

    IEnumerator Attack()
    {
        shootAudio.Play();
        GetComponent<Animation>().Play("ShootAnim");
        bulletsInMagazine--;
        GetComponentInParent<Player>().Attack();
        yield return new WaitForSeconds(timeBetweenAttacks);
        Player.isBusy = false;
    }
    IEnumerator MissFire()
    {
        misfireAudio.Play();
        yield return new WaitForSeconds(.1f);
        Player.isBusy = false;
    }
    IEnumerator Reload()
    {

        reloadAudio.Play();
        GetComponent<Animation>().Play("ReloadAnim");
        yield return new WaitForSeconds(reloadTime);
        var availableBullets = Math.Min(bullletCount, magazineSize);
        bulletSlot.amount -= availableBullets;
        if (bulletSlot.amount <= 0)
        {
            bulletSlot.RemoveItem();
        }
        else
        {
            bulletSlot.UpdateSlot(bulletItem.data, bulletSlot.amount);
        }
        bulletsInMagazine = availableBullets;
        Player.isBusy = false;

    }
    void Update()
    {
        bulletSlot = inventory.FindItemOnInventory(bulletItem.data);
        if(bulletSlot != null)
        {
            bullletCount = bulletSlot.amount;
        }
        if (Input.GetButtonDown("Reload") && !(Player.isBusy) && bulletSlot != null)
        {
            Player.isBusy = true;
            StartCoroutine(Reload());
        }
    }
    public override void DoAction()
    {
        Player.isBusy = true;
        if (bulletsInMagazine <= 0)
        {
            StartCoroutine(MissFire());
        }
        else
        {
            StartCoroutine(Attack());
        }
        
    }
}
