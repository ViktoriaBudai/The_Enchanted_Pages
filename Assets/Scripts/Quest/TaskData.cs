public class TaskData
{
    public string taskDescription;
    public bool isCompleted;

    public TaskData(string description)
    {
        taskDescription = description;
        isCompleted = false;
    }
}

