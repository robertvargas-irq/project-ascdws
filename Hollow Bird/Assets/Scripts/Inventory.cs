using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // private Hashtable inventoryItemNamesToCount = new Hashtable();
    private Hashtable inventoryItemNamesToObjects;
    private int itemCount = 0;
    private int currentWeight = 0; // pounds
    private int maxWeight = 50;    // pounds
    // Start is called before the first frame update
    // void Start()
    // {
    //     inventoryItemNamesToObjects = new Hashtable();
    // }

    // Add to inventory
    // Returns: True if added | False if full
    public bool add(Item item) {

        // if enough space is available, collect
        if (currentWeight < maxWeight)
        {
            // add to inventory
            inventoryItemNamesToObjects[item.itemName] = item;

            // modify inventory fields
            currentWeight += item.weight;
            itemCount++;
            return true;
        }
        return false;
    }

    // Remove from inventory
    // Returns: True if removed | False if not in the inventory
    public bool remove(Item item) {

        // if enough space is available, collect
        if (inventoryItemNamesToObjects.Contains(item.name))
        {
            inventoryItemNamesToObjects.Remove(item.itemName);
            currentWeight -= item.weight;
            itemCount--;
            return true;
        }
        return false;
    }

}
