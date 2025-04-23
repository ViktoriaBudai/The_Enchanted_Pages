using UnityEngine;
using UnityEngine.UI;

public class QuestPopupManager : MonoBehaviour
{
    public GameObject popupPanel;  // Reference to the Panel UI element
    public Button toggleButton;    // Reference to the toggle Button

    void Start()
    {
        // Initially hide the popup
        popupPanel.SetActive(false);

        // Add listener to the toggle button
        toggleButton.onClick.AddListener(TogglePopup);
    }

    public void TogglePopup()
    {
        // Check if the popup is currently active
        if (popupPanel.activeSelf)
        {
            // Hide the popup if it's active
            popupPanel.SetActive(false);
        }
        else
        {
            // Show the popup if it's inactive
            popupPanel.SetActive(true);
        }
    }
}


