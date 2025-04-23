using System.Collections.Generic;

public class QuestData
{
    public string questTitle;
    public string questDescription;
    public List<TaskData> tasks;

    public QuestData(string title, string description)
    {
        questTitle = title;
        questDescription = description;
        tasks = new List<TaskData>();
    }
}

