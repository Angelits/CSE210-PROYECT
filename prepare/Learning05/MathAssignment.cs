public class MathAssignment : Assignment
{
    private string homeworkList;

    public MathAssignment(string name, string topic, string homework)
        : base (name, topic)
        {
            this.homeworkList = homework;
        }

        public string GetHomeworkList()
        {
            return homeworkList;
        }
}