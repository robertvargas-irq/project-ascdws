using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNPC : Collidable
{
    public List<string> dialogue = new List<string>();
    // ! FRAMEWORK; NEEDS IMPLEMENTATION
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cat test NPC
    protected override void OnCollide(Collider2D collider)
    {   
        // show TEST message if not already shown
        if (messageShown || collider.name != "Player") return;

        int dialogueIndex = Random.Range(0, dialogue.Count - 1);
        
        GameManager.instance.ShowText(dialogue[dialogueIndex],25,Color.red,transform.position,Vector3.up * 50,1.5f);
        messageShown = true;
    }

    
}
