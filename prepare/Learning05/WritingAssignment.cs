
public class WritingAssignment : Assignment
{
    private string title;

    public WritingAssignment(string name, string topic, string title)
        : base(name, topic) // Call the base class constructor
    {
        this.title = title;
    }

    public string GetWritingInformation()
    {
        return $"{title} by {GetStudentName()}"; 
    }
}
