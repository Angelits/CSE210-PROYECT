
public class Assignment
{
    private string studentName;
    private string topic;

    public Assignment(string name, string topic)
    {
        this.studentName = name;
        this.topic = topic;
    }

    public string GetSummary()
    {
        return $"{studentName} - {topic}";
    }

    public string GetStudentName() 
    {
        return studentName;
    }
}
