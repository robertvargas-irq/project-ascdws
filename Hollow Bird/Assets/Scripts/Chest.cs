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
        
        // if locked, show locked message
        if (!messageShown)
        {
            GameManager.instance.ShowText("It seems to be locked...",25,Color.yellow,transform.position,Vector3.up * 50,1.5f);
            messageShown = true;
        }
    }

    protected override void OnCollect()
    {
        base.OnCollect();

        // swap sprite to an empty chest and remove blocking property
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
        // show message
        GameManager.instance.ShowText("You collected stuff!",25,Color.green,transform.position,Vector3.up * 50,1.5f);
    }
}

// trapped chest
// you've been poisoned!
// you feel dizzy
// - jen