using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;                  // filter to know what will be collided with
    private BoxCollider2D boxCollider;              // box collider on the object
    private Collider2D[] hits = new Collider2D[10]; // contains data on what is hit during a frame
    protected bool messageShown; // for floating text, maintain state if a message has been shown

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); // get collider from the object
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        // collision
        boxCollider.OverlapCollider(filter, hits);
        bool playerCollided = false; // becomes false if any value other than null appears
        
        for (int i = 0; i < hits.Length; i++)
        {
            // filter non-hits
            if (hits[i] == null)
                continue;
            
            // non-null value found, flip to false filtering out camera
            if (hits[i].name == "Player")
                playerCollided = true;

            // call collision script
            OnCollide(hits[i]);
            
            // clean up array
            hits[i] = null;
        }

        if (!playerCollided) messageShown = false;
    }

    /// <summary>
    /// Virtual prototype function for OnCollide event.
    /// </summary>
    /// <param name="collider">Array of objects that have collided with this object on the current frame.</param>
    protected virtual void OnCollide(Collider2D collider)
    {   
        // filter out only Players, or return on messageShown
        if (messageShown || collider.name != "Player") return;
        messageShown = true;
    }
}
