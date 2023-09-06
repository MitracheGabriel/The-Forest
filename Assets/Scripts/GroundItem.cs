using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour, InteractableItem
{
    public ItemObject item;
    public InventoryObject inventory;
    public int amount = 1;


    void Start()
    {
        var player = GameObject.Find("FPSController");
        if (player)
        {
            inventory = player.GetComponent<Player>().inventory;
        }
    }

    public void Interact()
    {
        if (inventory.AddItem(new Item(item), amount))
        {
            Destroy(gameObject);
        }

    }

}
