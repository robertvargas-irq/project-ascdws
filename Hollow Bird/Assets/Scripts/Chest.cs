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
    protected override void OnCollide(Collider2D collider)
    {
        // check if collected or not player
        if (collected || collider.name != "Player") return;

        // check lock state
        if (locked)
            Debug.Log("PLAYER, THIS CHEST IS LOCKED");
        else
            OnCollect();
    }

    protected override void OnCollect()
    {
        base.OnCollect();

        // swap sprite to an empty chest and notify the player of collection
        GetComponent<SpriteRenderer>().sprite = emptyChest;
        Debug.Log("HERE YOU GO!");
        Debug.Log("The contents have been successfully retrieved.");
    }
}
