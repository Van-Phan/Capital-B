﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void PickUp()
    {
<<<<<<< HEAD
        Debug.Log("Picked up  " + item.name);
        if (Inventory.instance.Add(item))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Couldn't Pick Up Item");
        }
=======
        Debug.Log("Picked up  " + transform.name);
        Inventory.instance.Add(Item); 
        Destroy(gameObject);
>>>>>>> parent of 6f6c7be... Revert "Adding item and inventory"
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
}
