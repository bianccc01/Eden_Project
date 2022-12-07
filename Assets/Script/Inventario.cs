using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventario 
{

    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int max;

        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            max = 9;
        }

        public bool CanAdd()
        {
            if(count < max)
            {
                return true;
            }
            return false;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventario (int numSlots)
    {
        for(int i=0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectable item)
    {
        foreach(Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAdd())
            {
                slot.AddItem(item);
                return;
            }
            
        }
        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

}
