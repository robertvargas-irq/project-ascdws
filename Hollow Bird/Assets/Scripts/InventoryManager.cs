using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public int currentCarryWeight = 0;
    public int maxCarryWeight = 30;

    // ! TESTING START
    public void Start()
    {
        Debug.Log("Current Weight: " + currentCarryWeight + " / " + maxCarryWeight);
        // for (int i = 0; i < 35; i++)
        //     GiveItem(0);
        // RemoveItem(0);
        // GiveItem(0);
        // Debug.Log("ITEM COUNT FOR " + itemDatabase.GetItem(0).itemName + ": " + ItemCount(0));
        // RemoveItem(0);
        // Debug.Log("ITEM COUNT FOR " + itemDatabase.GetItem(0).itemName + ": " + ItemCount(0));
    }

    // Get item count for a given item via instance reference
    public int ItemCount(Item item) {
        return characterItems.FindAll(i => i.itemId == item.itemId).Count;
    }

    // Get item count for a given item via ID
    public int ItemCount(int id) {
        return ItemCount(itemDatabase.GetItem(id));
    }

    // Get item count for a given item via Name
    public int ItemCount(string name) {
        return ItemCount(itemDatabase.GetItem(name));
    }

    // Add an item by ID to player's inventory | False if not able to add
    public bool GiveItem(int id) {
        return GiveItem(itemDatabase.GetItem(id));
    }

    // Add an item by Name to player's inventory | False if not able to add
    public bool GiveItem(string name) {
        return GiveItem(itemDatabase.GetItem(name));
    }

    // Add an item by Item instance reference | False if not able to add
    public bool GiveItem(Item item)
    {
        if (CanCarry(item))
        {
            characterItems.Add(item);
            currentCarryWeight += item.itemWeight;

            Debug.Log("Added item: " + item.itemName
            + "\nCurrent Weight: " + currentCarryWeight + " / " + maxCarryWeight);
            return true;
        }
        // if unable to carry, return false
        Debug.Log("The player is carrying too much already.");
        return false;
    }

    // Remove item by Item ID | False if the item was not in the inventory
    public bool RemoveItem(int id) {
        return RemoveItem(itemDatabase.GetItem(id));
    }

    // Remove item by Item Name | False if the item was not in the inventory
    public bool RemoveItem(string name) {
        return RemoveItem(itemDatabase.GetItem(name));
    }

    // Remove item by Item instance reference | False if the item was not in the inventory
    public bool RemoveItem(Item item) {
        bool removed = characterItems.Remove(item);
        if (removed)
        {
            currentCarryWeight -= item.itemWeight;
            Debug.Log("Removed item: " + item.itemName
            + "\nCurrent Weight: " + currentCarryWeight + " / " + maxCarryWeight);
        }
        else Debug.Log("Unable to remove item: ITEM NOT FOUND IN INVENTORY");

        return removed;
    }

    // Check to see if the player can carry new weight
    public bool CanCarry(Item item)
    {
        return (item.itemWeight + currentCarryWeight) <= maxCarryWeight;
    }
}
