using UnityEngine;

public class NPC : MonoBehaviour
{
    public Quest quest;
    private QuestManager questManager;

    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiveQuest();
        }
    }

    void GiveQuest()
    {
        questManager.AddQuest(quest);
        Debug.Log("Quest given: " + quest.questTitle);
    }
}

