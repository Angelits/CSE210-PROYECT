//As an extra for exceeding the requirements I added a feedback prompt with the structure if, else if and else regarding the user experience //
using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string Text => _text;

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }
}

public class Reference
{
    private string _referenceText;
    private List<Word> _words;

    public Reference(string referenceText, string scriptureText)
    {
        _referenceText = referenceText;
        _words = scriptureText.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(wordText => new Word(wordText))
                               .ToList();
    }

    public string ReferenceText => _referenceText;

    public List<Word> Words => _words;

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public void HideRandomWord(Random random)
    {
        int wordIndex;
        do
        {
            wordIndex = random.Next(_words.Count);
        } while (_words[wordIndex].IsHidden);

        _words[wordIndex].Hide();
    }
}

class Scripture
{
    private Dictionary<string, Reference> _scriptures;
    private Random _random;

    public Scripture()
    {
        _scriptures = new Dictionary<string, Reference>
        {
            { "Alma 32:35", new Reference("Alma 32:35", "Yea, because it is light and whatsoever is light is good") },
            { "John 3:16", new Reference("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life") },
            { "3 Nephi 18:20-21", new Reference("3 Nephi 18:20-21", "And whatsoever ye shall ask the Father in my name, which is right, believing that ye shall receive, behold it shall be given unto you. Pray in your families unto the Father, always in my name, that your wives and your children may be blessed") }
        };
        _random = new Random();
    }

    public void StartSession()
    {
        var scriptureKeys = _scriptures.Keys.ToList();
        var selectedScriptureKey = scriptureKeys[_random.Next(scriptureKeys.Count)];
        var selectedReference = _scriptures[selectedScriptureKey];

        Console.Clear();
        DisplayScripture(selectedReference);

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                Console.WriteLine("Program exiting. Thank you for participating!");
                break; 
            }
            else if (!selectedReference.AllWordsHidden)
            {
                selectedReference.HideRandomWord(_random);
                Console.Clear();
                DisplayScripture(selectedReference);
            }
            else
            {
                Console.WriteLine("All the words are hidden now. Exiting.");
                break; // 
            }
        }

        ProvideFeedback();
    }

    private void DisplayScripture(Reference reference)
    {
        Console.WriteLine(reference.ReferenceText);
        foreach (var word in reference.Words)
        {
            Console.Write(word.IsHidden ? new string('_', word.Text.Length) + " " : word.Text + " ");
        }
        Console.WriteLine();
    }

    private void ProvideFeedback()
    {
        Console.WriteLine("\nThank you for participating in this scripture study session, was this method useful? (yes/no)");
        var feedback = Console.ReadLine()?.ToLower();

        if (feedback == "yes")
        {
            Console.WriteLine("Glad to hear that!!, have an excellent day!");
        }
        else if (feedback == "no")
        {
            Console.WriteLine("Understood, thank you for the feedback. Have a good day");
        }
        else
        {
            Console.WriteLine("Thank you for your response! Have a great day!");
        }
    }
}

class Program
{
    static void Main()
    {
        var scriptureStudy = new Scripture();
        scriptureStudy.StartSession();
    }
}

