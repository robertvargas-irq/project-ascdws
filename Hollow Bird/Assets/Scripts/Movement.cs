using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected BoxCollider2D boxCollider; // the box collider of the child class
    private RaycastHit2D hit;
    private RaycastHit2D waterHit;
    public float waterResistance = 1.0F;
    public float moveMultiplier = 0.5F;
    protected string[] blockingMasks;
    protected bool collisions = true;

    // default movement blockers
    protected virtual void Start()
    {
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.blockingMasks = new string[]{"Actor", "Border", "Blocking"};
    }
    public void MoveDirection(Vector2 moveDelta, bool normalized = true)
    {
        // normalize inputs
        if (normalized)
            moveDelta.Normalize();
        
        // swap sprite direction based on direction
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        
        // raycast in place for water (Y-AXIS)
        if (waterResistance != 1.0f)
            waterHit = Physics2D.BoxCast(
                transform.position,
                boxCollider.size,
                0,
                new Vector2(0, moveDelta.y),
                Mathf.Abs(moveDelta.y * moveMultiplier * Time.deltaTime),
                LayerMask.GetMask("Water")
            );

        // raycast (Y-AXIS)
        if (collisions)
            hit = Physics2D.BoxCast(
                transform.position,
                boxCollider.size,
                0,
                new Vector2(0, moveDelta.y),
                Mathf.Abs(moveDelta.y * moveMultiplier * Time.deltaTime),
                LayerMask.GetMask(blockingMasks)
            );

        // if no collision from raycast, move sprite
        if (!collisions || hit.collider == null)
            transform.Translate(0, moveDelta.y * moveMultiplier * Time.deltaTime * (waterHit.collider != null ? waterResistance : 1.0f), 0);

        // raycast in place for water (X-AXIS)
        if (waterResistance != 1.0f)
            waterHit = Physics2D.BoxCast(
                transform.position,
                boxCollider.size,
                0,
                new Vector2(moveDelta.x, 0),
                Mathf.Abs(moveDelta.x * moveMultiplier * Time.deltaTime),
                LayerMask.GetMask("Water")
            );

        // raycast (X-AXIS)
        if (collisions)
            hit = Physics2D.BoxCast(
                transform.position,
                boxCollider.size,
                0,
                new Vector2(moveDelta.x, 0),
                Mathf.Abs(moveDelta.x * moveMultiplier * Time.deltaTime),
                LayerMask.GetMask(blockingMasks)
            );

        // if no collision from raycast, move sprite
        if (!collisions || hit.collider == null)
        {
            transform.Translate(
                moveDelta.x * moveMultiplier * Time.deltaTime * (waterHit.collider != null ? waterResistance : 1.0f), 0, 0);
        }
    }
}
