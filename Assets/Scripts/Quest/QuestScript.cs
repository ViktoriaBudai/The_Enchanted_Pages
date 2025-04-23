using UnityEngine;

public class QuestScripts : MonoBehaviour
{
    void Start()
    {
        // Load the text file from the Resources folder
        TextAsset questText = Resources.Load<TextAsset>("Assets/Scripts/Quest/text.txt");

        if (questText != null)
        {
            Debug.Log(questText.text);
        }
        else
        {
            Debug.LogError("Text file not found!");
        }
    }
}
