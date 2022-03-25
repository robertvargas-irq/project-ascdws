using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Collectable
{
    private ItemInfo info; // information
    public string itemName;
    public int weight;
    public ItemInfo.KeyTypes keyType;
    protected override void Start() 
    {
        base.Start();

        info = new ItemInfo(keyType, weight, itemName);
    }
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
        Destroy(this, 0.1F);
    }
}
