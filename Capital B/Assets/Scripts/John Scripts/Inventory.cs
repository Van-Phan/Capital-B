using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private const int MAX_INVENTORY_SIZE = 10;
    //delegate is used to trigger changes in InventoryUI
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory found.");
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();

    //adds item to our items list 
    public bool Add(Item item)
    {
        if (!item.isDefaultItem && items.Count < MAX_INVENTORY_SIZE)
        {
            items.Add(item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
            return true;
        }

        return false;
    }

    //removes item from our items list
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
