using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // stores item objects
    public List<Item> items = new List<Item>();

    // Awake is called upon game start
    void Awake()
    {
        BuildDatabase();
    }

    // Get item by ID
    public Item GetItem(int id)
    {
        return items.Find(item => item.itemId == id);
    }

    // Get item by Name
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.itemName == itemName);
    }

    void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(
                0, 1, "Silver Key", "This key looks like it might fit a chest...",
                new Dictionary<string, int>()
            ),
            new Item(
                1, 2, "Special Blue Key", "This key is a bit heavier than the others. I think it's... glowing?",
                new Dictionary<string, int>()
            )
        };

        foreach (Item item in items)
        {
            Debug.Log(item);
        }
    }
}
