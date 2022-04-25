using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Movement
{
    private Vector3 moveDelta;
    private RaycastHit2D hitX;
    private RaycastHit2D hitY;
    public Transform target; // focus for movement/direction of sprite
    public bool focusing;    // if focusing on target, will move sprite to look at target
    public bool limitedRange; // if range is limited
    public float range = 1.0f; // range if limited
    public int maxHealth;
    public int health;
    public bool standingStill;
    private Sprite facingForward;
    public Sprite facingBackward;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Screen.SetResolution(800, 600, true);
        // grab components
        boxCollider = GetComponent<BoxCollider2D>();
        facingForward = GetComponent<SpriteRenderer>().sprite;

        // if no sprite set for turning around, default forward
        if (!facingBackward) facingBackward = facingForward;
    }

    // FixedUpdate is called at 50fps
    void FixedUpdate()
    {
        // if not focusing, do nothing
        if (!focusing) return;

        // get offsets from current NPC game object
        float deltaX = target.position.x - transform.position.x;
        float deltaY = target.position.y - transform.position.y;

        // if out of range, do nothing
        if (limitedRange && (deltaX > range || deltaY > range)) return;

        // swap the sprite's direction if necessary
        if (deltaX > 0) transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        else transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        if (deltaY < 0) GetComponent<SpriteRenderer>().sprite = facingForward;
        else GetComponent<SpriteRenderer>().sprite = facingBackward;

        // if not standing still, move towards the focal point
        if (standingStill || moveMultiplier == 0) return;
        MoveDirection(new Vector2(deltaX, deltaY));
        return;
    }
}
