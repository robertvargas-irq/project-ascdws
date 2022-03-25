using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Hashtable inventoryItemNamesToObjects;
    private int itemCount = 0;
    private int currentWeight = 0; // pounds
    private int maxWeight = 50;    // pounds
    public bool add(ItemManager item) {

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
    public bool remove(ItemManager item) {

        // if enough space is available, collect
        if (inventoryItemNamesToObjects.Contains(item.itemName))
        {
            inventoryItemNamesToObjects.Remove(item.itemName);
            currentWeight -= item.weight;
            itemCount--;
            return true;
        }
        return false;
    }

}
