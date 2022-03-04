using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    protected bool collected; // collectable object been collected from

    /// <summary>
    /// Check if collider is a Player.
    /// </summary>
    /// <param name="collider"></param>
    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name == "Player")
            OnCollect();
    }

    /// <summary>
    /// Set collected to true.
    /// </summary>
    protected virtual void OnCollect()
    {
        collected = true;
    }
}
