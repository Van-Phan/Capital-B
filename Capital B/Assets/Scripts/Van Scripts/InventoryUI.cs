using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject crossHair;

    InventorySlot[] slots;

    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        //list of the slots for our inventory
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        //edit > project settings > input manager
        //if player presses I or B
        if (Input.GetButtonDown("Inventory"))
        {
            //change active state of inventory to show/hide it
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            //changes cursor based on whether inventory is active or not
            //if inventory is open we want to unlock the mouse
            if (inventoryUI.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                //changes the crosshair to be disabled when you open your inventory
                crossHair.SetActive(!inventoryUI.activeSelf);
            }
            else
            {
                //locks and hides cursor to middle of screen, press escape to enable mouse
                Cursor.lockState = CursorLockMode.Locked;
                //changes the crosshair to be disabled when you open your inventory
                crossHair.SetActive(!inventoryUI.activeSelf);
            }
        }
    }

    //updates whether items are in or no in slots
    void UpdateUI()
    {
        Debug.Log("Updating UI.");
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
