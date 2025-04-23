using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int amount;
    public bool isKey;
}

