using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                //Debug.Log("Inventory found.");
                if (inventory.HasKey())
                {
                    //Debug.Log("Player has the key.");
                    OpenDoor();
                }
                else
                {
                    //Debug.Log("The player needs a key to open this door.");
                }
            }
            else
            {
                //Debug.Log("No Inventory component found on player.");
            }
        }
    }

    private void OpenDoor()
    {
        doorAnimator.SetBool("isOpen", true);
        //Debug.Log("Door opened!");
    }
}



