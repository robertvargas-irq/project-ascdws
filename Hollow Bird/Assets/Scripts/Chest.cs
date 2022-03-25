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
    public string[] itemsHeld;
    public bool pause = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        // call super's Start
        base.Start();

        // disable inner collider if collected
        if (collected)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        // TEST INPUT
        if (gameObject.name == "Chest")
            itemsHeld = new string[]{"20 Rocks", "2 Gold", "1 Feather"};
    }
    
    // collision handler
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
            locked = false;
            GameManager.instance.ShowText("That branch seemed to do the trick-!",15,Color.green,collider.transform.position,Vector3.zero,1.5f);
            return;
        }
        
        // if locked, show locked message
        if (locked && !messageShown)
        {
            GameManager.instance.ShowText("It seems to be locked...",15,Color.yellow,collider.transform.position  - Vector3.down * 0.1f,Vector3.zero,1.5f);
            messageShown = true;
        }
    }

    protected override void OnCollect()
    {
        base.OnCollect();

        // swap sprite to an empty chest and remove blocking property
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        // show empty message
        if (itemsHeld.Length < 1)
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
        foreach (string item in itemsHeld)
        {
            GameManager.instance.ShowText("" + item + "!",15,Color.magenta,transform.position,Vector3.up + new Vector3(0, offset++, 0) * 0.5f * 50,1.5f);
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