using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests = new List<Quest>();
    public QuestUI questUI;


    public void AddQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            Debug.Log("Quest added: " + quest.questTitle);
            questUI.UpdateQuestList();
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (activeQuests.Contains(quest) && !quest.isCompleted)
        {
            quest.isCompleted = true;
            Debug.Log("Quest completed: " + quest.questTitle);
            questUI.UpdateQuestList();
        }
    }
}



