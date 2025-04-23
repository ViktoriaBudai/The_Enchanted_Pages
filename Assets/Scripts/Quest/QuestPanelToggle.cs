using UnityEngine;
using UnityEngine.UI;

public class QuestPanelToggle : MonoBehaviour
{
    public GameObject questPanel;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        questPanel.SetActive(!questPanel.activeSelf);
    }
}

