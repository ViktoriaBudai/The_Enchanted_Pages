using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public QuestManager questManager;
    public TextMeshProUGUI questListText;

    void Update()
    {
        UpdateQuestList();
    }


    public void UpdateQuestList()
    {
        questListText.text = "";
        foreach (Quest quest in questManager.activeQuests)
        {
            questListText.text += quest.questTitle + (quest.isCompleted ? " (Completed)" : "") + "\n";
        }
    }
}



