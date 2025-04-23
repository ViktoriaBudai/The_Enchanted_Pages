using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public Vector3 openRotation;  // The rotation for the door when it's open
    public float animationDuration = 1f;  // Duration of the opening animation
    private Vector3 closedRotation;  // The original rotation of the door
    private bool isOpen = false;

    void Start()
    {
        closedRotation = transform.eulerAngles;  // Save the original rotation of the door
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null && inventory.HasKey())
            {
                if (!isOpen)
                {
                    StartCoroutine(OpenDoor());
                }
            }
            else
            {
                Debug.Log("The player needs a key to open this door.");
            }
        }
    }

    private IEnumerator OpenDoor()
    {
        isOpen = true;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            transform.eulerAngles = Vector3.Lerp(closedRotation, openRotation, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = openRotation;  // Ensure it's fully opened at the end
        Debug.Log("Door opened!");
    }
}

