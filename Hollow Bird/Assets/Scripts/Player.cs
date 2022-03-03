using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // get input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // reset moveDelta
        moveDelta = new Vector3(x, y, 0);

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
            Mathf.Abs(moveDelta.y * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking")
        );

        // if no collision from raycast, move sprite
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // raycast (X-AXIS)
        hit = Physics2D.BoxCast(
            transform.position,
            boxCollider.size,
            0,
            new Vector2(moveDelta.x, 0),
            Mathf.Abs(moveDelta.x * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking")
        );

        // if no collision from raycast, move sprite
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
