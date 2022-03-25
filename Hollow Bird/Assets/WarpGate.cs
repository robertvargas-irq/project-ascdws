using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : Collidable
{
    public WarpGate link;
    public Vector3 linkPos;
    public Camera cam;
    public bool outLeft = false;
    public bool outRight = false;
    public bool outDown = false;
    public bool outUp = false;
    public float outOffset = 0.15F;

    protected override void Start()
    {
        base.Start();
        cam = GameObject.FindObjectOfType<Camera>();
        linkPos = link.transform.position;
    }
    protected override void OnCollide(Collider2D collider)
    {
        base.OnCollide(collider);

        // teleport player only
        if (collider.name != "Player") return;

        // teleport player
        if (outLeft)
            collider.transform.position = new Vector3(linkPos.x + outOffset, linkPos.y, 0);
        if (outRight)
            collider.transform.position = new Vector3(linkPos.x - outOffset, linkPos.y, 0);
        
        if (outDown)
            collider.transform.position = new Vector3(linkPos.x, linkPos.y - outOffset, 0);
        else if (outUp)
            collider.transform.position = new Vector3(linkPos.x, linkPos.y + outOffset, 0);
        
        // teleport camera
        cam.transform.position = collider.transform.position;

    }
}
