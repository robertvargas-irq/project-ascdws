using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Chest driver and behavior.
/// </summary>
/// <extends>Collidable</extends>
/// 
public class Chest : Collectable
{
    public Sprite emptyChest;
    public bool locked = true; // lock state
    public List<Item> itemsHeld = new List<Item>();
    public bool pause = false;
    public bool specialChest = false; // will indicate the need for a special key
    public int unlockKeyId = 0;       // 0: Silver | 1: Blue
    private Item unlockKeyItemReference; // Item instance for key
    private bool tooltipShown = false;   // to not spam a tooltip

    protected override void Start()
    {
        // call super's Start
        base.Start();

        // disable inner collider if collected
        if (collected)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        // assign key type needed for unlock
        if (specialChest) unlockKeyId = 1;
        else unlockKeyId = 0;

        // ! TEST INPUT
        if (gameObject.name == "Chest")
            itemsHeld = new List<Item>()
            {
                itemDatabase.GetItem(0),
                itemDatabase.GetItem(0),
                itemDatabase.GetItem(0)
            };
        
        // assign the proper key to unlock
        unlockKeyItemReference = itemDatabase.GetItem(unlockKeyId);
    }

    // Check to see if the proper key is held by the player
    private bool HasKey()
    {
        return GameManager.instance.player.inventory.ItemCount(unlockKeyItemReference) > 0;
    }
    
    // Collision handler: On collider hit
    protected override void OnCollide(Collider2D collider)
    {
        // check if collected or not player
        if (collected || collider.name != "Player") return;

        // if not locked, allow collection
        if (!locked) {
            OnCollect();
            return;
        }
        
        // if locked see if player is interacting to unlock
        if (Input.GetButton("Fire3"))
        {
            // check to see if the proper key was used
            if (HasKey())
            {
                // unlock and remove key
                locked = false;
                GameManager.instance.ShowText(
                    "That " + unlockKeyItemReference.itemName + " seemed to do the trick-!",
                    15,
                    Color.green,
                    collider.transform.position,
                    Vector3.zero,
                    1.5f
                );
                GameManager.instance.player.inventory.RemoveItem(unlockKeyItemReference);
            }
            else if (!tooltipShown)
            {
                GameManager.instance.ShowText(
                    "Hmm... if only I had a key...",
                    15,
                    Color.grey,
                    collider.transform.position,
                    Vector3.zero,
                    1.5f
                );
                tooltipShown = true;
            }
            return;
        }
        // reset tooltip when button is released
        else tooltipShown = false;
        
        // if locked, show locked message
        if (locked && !messageShown)
        {
            GameManager.instance.ShowText("It seems to be locked...",15,Color.yellow,collider.transform.position  - Vector3.down * 0.1f,Vector3.zero,1.5f);
            messageShown = true;
        }
    }

    // Collection handler: If able to collect
    protected override void OnCollect()
    {
        base.OnCollect();

        // swap sprite to an empty chest and remove blocking property
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        // show empty message
        if (itemsHeld.Count < 1)
        {
            string[] random = new string[]{"Nothing but dust...", "I can hear a cricket, but see no items.", "The chest was empty.", "Unfortunately, you've been bamboozled."};
            GameManager.instance.ShowText(
                random[Random.Range(0, random.Length)],
                15,
                Color.magenta,
                transform.position,
                Vector3.up * 0.5f * 50,
                1.5f);
            return;
        }

        // show rewards
        string itemList = "";
        float offset = 0.4f;
        foreach (Item item in itemsHeld)
        {
            GameManager.instance.player.inventory.GiveItem(item);
            GameManager.instance.ShowText("" + item.itemName + "!",15,Color.magenta,transform.position,Vector3.up + new Vector3(0, offset++, 0) * 0.5f * 50,1.5f);
            itemList += item + ", ";
        }
        itemList.Substring(0, itemList.Length - 2);
        // GameManager.instance.ShowText("Collected " + itemList + "!",15,Color.magenta,transform.position,Vector3.up * 0.5f * 50,1.5f);
    }
}

// trapped chest
// you've been poisoned!
// you feel dizzy
// - jen