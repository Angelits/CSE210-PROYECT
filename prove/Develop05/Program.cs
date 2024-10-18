//For exceeding the requirements I created a new activity called finding a calm place, this is a technique used to soathe and calm anxiety I learned
//when I was going through a hard time and is very helpful!
using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        MindfulActivity activity = null;
        while (true)
        {
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Calm Place Activity"); 
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new CalmPlaceActivity(); 
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            activity.Run();
        }
    }
}

public abstract class MindfulActivity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public void StartActivity(string description)
    {
        Console.WriteLine($"Starting Activity: {_activityName}");
        Console.WriteLine(description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        Pause(3);
    }

    public void FinishActivity()
    {
        Console.WriteLine("Good job!!");
        Pause(3);
        Console.WriteLine($"You completed the activity for {_duration} seconds.");
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rLoading... {i} seconds remaining.");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}

public class BreathingActivity : MindfulActivity
{
    public BreathingActivity()
    {
        _activityName = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        StartActivity(_description);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Pause(4);
            Console.WriteLine("Breathe out...");
            Pause(4);
        }

        FinishActivity();
    }
}

public class ReflectionActivity : MindfulActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        _activityName = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    public override void Run()
    {
        StartActivity(_description);

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Pause(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine(question);
            Pause(5);
        }

        FinishActivity();
    }
}

public class ListingActivity : MindfulActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _activityName = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life.";
    }

    public override void Run()
    {
        StartActivity(_description);

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Pause(5);

        Console.WriteLine("Start listing items (press Enter after each):");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrEmpty(item))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} items.");
        FinishActivity();
    }
}

public class CalmPlaceActivity : MindfulActivity
{
    public CalmPlaceActivity()
    {
        _activityName = "Calm Place Activity";
        _description = "This activity will help you relax by guiding you to a calm place in your mind. Focus on the details around you.";
    }

    public override void Run()
    {
        StartActivity(_description);

        Console.Write("Think of a calm and beautiful place you like: ");
        string calmPlace = Console.ReadLine();
        Console.WriteLine($"Imagine you are in {calmPlace}. Take a moment to settle in...");
        Pause(5); 

        Console.WriteLine("Now, try to locate some objects in your calm place.");
        Console.Write("What do you see? ");
        string object1 = Console.ReadLine();
        Console.Write("What sounds do you hear? ");
        string sound1 = Console.ReadLine();
        Console.Write("What do you smell? ");
        string smell1 = Console.ReadLine();

        Console.WriteLine($"In your calm place, you see {object1}, hear {sound1}, and smell {smell1}.");
        Console.WriteLine("Take a few deep breaths and enjoy this peaceful moment.");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Continue to visualize your calm place...");
            Pause(5);
        }

        FinishActivity();
    }
}
