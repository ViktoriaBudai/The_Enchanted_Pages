using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickupItem(other);
        }
    }

    void PickupItem(Collider player)
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(item);
            Debug.Log("Item picked up: " + item.itemName);
            Destroy(gameObject);
        }
    }
}


