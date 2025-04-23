using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Added item: " + item.itemName);  // Check this log message
    }

    public bool HasKey()
    {
        Debug.Log("Checking for key...");
        foreach (Item item in items)
        {
            Debug.Log("Inventory item: " + item.itemName + ", isKey: " + item.isKey);
            if (item.isKey)
            {
                Debug.Log("Key found in inventory.");
                return true;
            }
        }
        Debug.Log("No key found in inventory.");
        return false;
    }
}



