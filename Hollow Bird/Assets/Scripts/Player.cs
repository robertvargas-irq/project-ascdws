using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Movement
{
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public HealthBar HealthBar;
    public ThirstBar ThirstBar;
    private float seconds = 0.0f; 

    // health for player
    public int maxHealth = 20;
    public int maxThirst = 100;
    public int currentHealth; // health
    public int currentThirst; // thirst

    public float regenRate = 3.0f; // base health regen
    public float regeneration = 1; // amount healed based on time and debuff

    private SpriteRenderer spriteRenderer;
   
    public InventoryManager inventory;
    public ItemDatabase itemDatabase;

    // Start is called before the first frame update
    protected override void Start()
    {
        // call parent start
        base.Start();

        // set health for player upon start
        HealthBar.SetHealth(currentHealth);
        HealthBar.SetMaxHealth(maxHealth);

        ThirstBar.SetThirst(currentThirst);
        ThirstBar.SetMaxThirst(maxThirst);

        ThirstHealthDebuf();

        //renders the sprite upon start
        spriteRenderer = GetComponent<SpriteRenderer>();
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

    // Remove from the Thirst bar, making the player Thirstier
    void BecomeThirst(int thirst)
    {
        // validate input
        if (currentThirst - thirst < 0)
            currentThirst = 0;
        // subtract thirst and update visual if valid
        else
            currentThirst -= thirst;
            ThirstBar.SetThirst(currentThirst);
    }

    // Add to the Thirst bar, satiating the player's Thirst
    void RecoverThirst(int thirst)
    {
        // validate input
        if (currentThirst + thirst > maxThirst)
            currentThirst = maxThirst;
        // add thirst and update visual if valid
        else
            currentThirst += thirst;
            ThirstBar.SetThirst(currentThirst);
    }


    // PRE: nada
    // POST: return a float for time spent waiting to heal
    // Note: with each factor of 25, thirst will increase by 5% from EACH STEP
    // STAY HYDRATED
    float ThirstHealthDebuf()
    {
        // return rate based on increments of 25 thirst
        if(currentThirst > 75)
        {
            regenRate = 3.0f;
        }
        else if (currentThirst <= 75 && currentThirst > 50 ) 
        {
            regenRate = 4.5f;
        }
        else if (currentThirst <= 50 && currentThirst > 25 ) 
        {
            regenRate = 6.75f;
        }
        else if (currentThirst <= 25 && currentThirst > 0)
        {
            regenRate = 10.125f;
        }
        else {
            regenRate = 100;
        }
        return regenRate;
    }

    // Regenerate health over an interval defined by the current thirst
    void HealthRegen()
    {
        if (currentHealth < maxHealth) 
        {
            seconds += Time.deltaTime;
            if(seconds >= ThirstHealthDebuf()) // call thirst debuff for regen rate
            {
                currentHealth = (int)Mathf.Min(currentHealth + regeneration, maxHealth); // casted to int for currentHealth
                seconds = 0;
            }
        }
        HealthBar.SetHealth(currentHealth);
    }


    // Update is called once per frame
    void Update()

    {
        // tester for damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }

        HealthRegen(); // call regen health

        // tester for thirst down
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            BecomeThirst(25);
        }

        // tester for thirst
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            RecoverThirst(25);
        }
        
        
    }

    public void SwapSprite(int skinID)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinID];
    }

}
