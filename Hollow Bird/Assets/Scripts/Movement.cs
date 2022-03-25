using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected BoxCollider2D boxCollider; // the box collider of the child class
    private RaycastHit2D hit;
    private float waterResistance;
    public float moveMultiplier = 0.5F;
    protected string[] blockingMasks;

    // default movement blockers
    protected virtual void Start()
    {
        this.blockingMasks = new []{"Actor", "Blocking"};
    }
    public void MoveDirection(Vector2 moveDelta)
    {
        // normalize inputs
        moveDelta.Normalize();
        
        // swap sprite direction based on direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // raycast (Y-AXIS)
        hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0,
            new Vector2(0, moveDelta.y),
            Mathf.Abs(moveDelta.y * moveMultiplier * Time.deltaTime),
            LayerMask.GetMask(blockingMasks)
        );

        // if no collision from raycast, move sprite
        if (hit.collider == null)
            transform.Translate(0, moveDelta.y * moveMultiplier * Time.deltaTime, 0);

        // raycast (X-AXIS)
        hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0,
            new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * moveMultiplier * Time.deltaTime),
            LayerMask.GetMask(blockingMasks)
        );

        // if no collision from raycast, move sprite
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * moveMultiplier * Time.deltaTime, 0, 0);
        }
    }
}
