using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int itemId;
    public string itemName;
    public string itemDescription;
    public int itemWeight;
    public Sprite itemIcon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    // Create an item object
    public Item(int id, int weight, string name, string description, Dictionary<string, int> stats)
    {
        this.itemId = id;
        this.itemWeight = weight;
        this.itemName = name;
        this.itemDescription = description;
        this.itemIcon = Resources.Load<Sprite>($"Sprites/Items/{itemName}");
        this.stats = stats;
    }

    // Deep-copy an item
    public Item(Item item)
    {
        this.itemId = item.itemId;
        this.itemWeight = item.itemWeight;
        this.itemName = item.itemName;
        this.itemDescription = item.itemDescription;
        this.itemIcon = Resources.Load<Sprite>($"Sprites/Items/{item.itemName}");
        this.stats = item.stats;
    }

    public override string ToString()
    {
        string statsString = "{\n";
        foreach (KeyValuePair<string, int> kv in this.stats)
            statsString += "\t\t" + kv.Key + ": " + kv.Value + "\n";
        statsString += "\t}";

        return "ITEM ID (" + this.itemId + ") {\n"
            + "\tWeight: " + this.itemWeight + "\n"
            + "\tName: " + this.itemName + "\n"
            + "\tDescription: " + this.itemDescription + "\n"
            + "\tStats: " + statsString + "\n"
            + "}\n";
    }
}
