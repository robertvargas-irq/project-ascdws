using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    // key classes
    public enum KeyTypes {
        NotAKey,
        RegularChest,
        DarkChest

    }
    KeyTypes keyType = KeyTypes.RegularChest; // 0: not a key; 1->n specific key types
    KeyTypes KeyType
    {
        get {return keyType;}
    }
    public int weight = 0;  // weight of the item
    public string itemName;
    public ItemInfo(KeyTypes keyType, int weight, string itemName)
    {
        this.keyType = keyType;
        this.weight = weight;
        this.itemName = itemName;
    }
}
