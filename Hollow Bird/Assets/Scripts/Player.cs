using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public float moveMultiplier = 1;
    public HealthBar HealthBar;

    // health for player
    public int maxHealth = 20;
    public int currentHealth;
    public Inventory inventory = new Inventory();

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        // set health for player upon start
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);


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
            Mathf.Abs(moveDelta.y * moveMultiplier * Time.deltaTime),
            LayerMask.GetMask("Actor", "Blocking")
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
            LayerMask.GetMask("Actor", "Blocking")
        );

        // if no collision from raycast, move sprite
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * moveMultiplier * Time.deltaTime, 0, 0);
        }

    }

    // input damage to player or NPC
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // set damage to healthbar
        HealthBar.SetHealth(currentHealth);
        GameManager.instance.ShowText("That hurt.... :(", 25, Color.red, transform.position, Vector3.up * 50,.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // tester for damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
    }
}
