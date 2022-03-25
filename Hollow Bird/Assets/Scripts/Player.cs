using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public HealthBar HealthBar;

    // health for player
    public int maxHealth = 20;
    public int currentHealth;
    public InventoryManager inventory;

    // Start is called before the first frame update
    protected override void Start()
    {
        // call parent start
        base.Start();

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
        MoveDirection(new Vector2(x, y));
        return;

    }

    // input damage to player or NPC
    void TakeDamage(int damage)
    {
        // subtract from health
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
