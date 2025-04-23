using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public QuestPopupManager questPopupManager;  // Reference to the QuestPopupManager

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the quest popup when the player interacts with the NPC
            questPopupManager.TogglePopup();
        }
    }
}

