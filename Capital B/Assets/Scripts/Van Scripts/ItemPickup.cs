using System.Collections;
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

    //picks up item if possible and returns input to console log
    void PickUp()
    {
        if (Inventory.instance.Add(item))
        {
            Debug.Log("Picked up  " + item.name);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Couldn't Pick Up Item");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            //determines if player is close enough to the item interaction area to interact with the item
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
}
