using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI inventoryText;
    public GameObject inventoryPanel;

    void Update()
    {
        if (inventoryPanel.activeSelf)
        {
            UpdateInventoryUI();
        }
    }

    void UpdateInventoryUI()
    {
        inventoryText.text = "Inventory:\n";
        foreach (Item item in inventory.items)
        {
            inventoryText.text += item.itemName + "\n";
        }
    }

    public void ToggleInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}


