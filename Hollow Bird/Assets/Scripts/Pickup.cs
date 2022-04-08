using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Collectable
{
    public int itemId;
    public Item itemInstance;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        // override properties with item from the database
        itemInstance = itemDatabase.GetItem(itemId);
    }

    protected override void OnCollide(Collider2D collider)
    {
        // filter only the player
        if (!collected && collider.name == "Player")
        {
            var playerInventory = GameManager.instance.player.inventory;
            // if there is space in the player's inventory, pick up
            if (playerInventory.CanCarry(itemInstance))
            {
                OnCollect();
                GameManager.instance.ShowText(
                    "This looks like it might come in handy.",
                    15,
                    Color.green,
                    collider.transform.position,
                    Vector3.zero,
                    1.5f
                );
            }
            else if (!messageShown)
            {
                GameManager.instance.ShowText(
                    "Hhh... I'm already carrying too much...",
                    15,
                    Color.red,
                    collider.transform.position,
                    Vector3.zero,
                    1.5f
                );
                messageShown = true;
            }
        }
    }

    protected override void OnCollect()
    {
        base.OnCollect();

        GameManager.instance.player.inventory.GiveItem(itemInstance);

        Destroy(gameObject);

    }
}
