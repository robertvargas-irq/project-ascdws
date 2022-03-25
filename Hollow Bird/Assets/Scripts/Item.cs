using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collectable
{
    // key classes
    enum KeyTypes {
        NotAKey,
        RegularChest,
        DarkChest

    }
    KeyTypes keyType = KeyTypes.RegularChest; // 0: not a key; 1->n specific key types
    public int weight = 0;  // weight of the item
    public string itemName;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            Player p = GameManager.instance.player;

            // give player
            if (p.inventory.add(this))
            {
                OnCollect();
                GameManager.instance.ShowText("This may come of use.", 25, Color.cyan, transform.position, Vector3.up * 50,.5f);
            }
            else
                GameManager.instance.ShowText("I'm already carrying too much.", 25, Color.red, transform.position, Vector3.up * 50,.5f);
        }
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        Destroy(this, 1);
    }
}
