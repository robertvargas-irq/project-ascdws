using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected; // collectable object been collected from
    protected ItemDatabase itemDatabase; // database of all in-game items

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // get the item database
        itemDatabase = GameManager.instance.itemDatabase;
    }

    // Check if collider is a Player.
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Player")
            OnCollect();
    }

    // Set collected to true.
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
