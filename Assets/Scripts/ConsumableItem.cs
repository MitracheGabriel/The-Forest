using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : ActionItem
{
    public int healthValue = 5;

    public ItemObject item;
    public InventoryObject inventory;
    public AudioSource consumeAudio;

    public override void DoAction()
    {
        if (!Player.isBusy)
        {
            Player.isBusy = true;
            StartCoroutine(Consume());
        }
    }
    IEnumerator Consume()
    {     
        var slot = inventory.FindItemOnInventory(item.data);
        if(slot != null)
        {
            GetComponent<Animation>().Play("Consume");
            consumeAudio.Play();
            yield return new WaitForSeconds(1);
            PlayerStats.SetCurrentHealth(PlayerStats.currentHealth + healthValue);
            slot.UpdateSlot(slot.item, slot.amount -= 1);
           if(slot.amount <= 0)
            {
                    slot.RemoveItem();   
            }

        }
        Player.isBusy = false;
    }
}
