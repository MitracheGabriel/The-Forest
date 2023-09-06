using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StaticInterface : UserInterface
{
    public GameObject[] slots;

    public override void CreateSlots()
    {
        slotsOnInterface = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.GetSlots.Length; i++)
        {
            var obj = slots[i];

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); PointerEnter(); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); PointerExit(); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); BeginDrag(); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); EndDrag(); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); Drag(); });

            inventory.GetSlots[i].slotDisplay = obj;

            slotsOnInterface.Add(obj, inventory.GetSlots[i]);
        }
    }
    public void PointerEnter()
    {
        Debug.Log("PointerEnter");
    } 
    public void PointerExit()
    {
        Debug.Log("PointerExit");

    }
    public void BeginDrag()
    {
        Debug.Log("BeginDrag");
    }
    public void EndDrag()
    {
        Debug.Log("EndDrag");
    } 
    public void Drag()
    {
        Debug.Log("Drag");
    }
}
