using System;

class Program
{
    static void Main(string[] args)
    {

       string[] names = {"Samuel Bennet", "Alicia Domingo", "Jeremy Smith", "Linda Rock"};
       string[] topics = {"Multiplication", "Division", "Fractions", "Substraction", "Algebra"};

       Random random = new Random();

       string randomName = names[random.Next(names.Length)];
       string randomTopic = topics[random.Next(topics.Length)];

       Assignment assignment = new Assignment (randomName, randomTopic);

       MathAssignment mathAssignment = new MathAssignment(randomName, randomTopic, "1.Solve 5 substraction problems \n2. Complete the Geometry sheet");

       string summary = mathAssignment.GetSummary();
       Console.WriteLine(summary);

       string homework = mathAssignment.GetHomeworkList();
       Console.WriteLine("Homework List:\n" + homework);

       WritingAssignment writingAssignment = new WritingAssignment(randomName, "European History", "The Causes of World War II");
        
        // Get the summary and writing information
        string writingSummary = writingAssignment.GetSummary();
        Console.WriteLine(writingSummary);
        string writingInfo = writingAssignment.GetWritingInformation();
        Console.WriteLine(writingInfo);
    }
}