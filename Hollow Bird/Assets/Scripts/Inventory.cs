using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Hashtable inventory;
    private int itemCount = 0;
    private int currentWeight = 0; // pounds
    private int maxWeight = 50;    // pounds
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Add to inventory
    // Returns: True if added | False if full
    public bool add(Object item) {

        
        return true;
    }

}
