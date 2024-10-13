using System;
using System.Collections.Generic;

public class Comment
{
    private string _person;
    private string _comment;

    public Comment(string person, string comment)
    {
        _person = person;
        _comment = comment;
    }

    public string GetPerson()
    {
        return _person;
    }

    public string GetComment()
    {
        return _comment;
    }
}

public class Video
{
    private string _trackTitle;
    private string _trackAuthor;
    private int _trackLength; 
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _trackTitle = title;
        _trackAuthor = author;
        _trackLength = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string DisplayVideoDetails()
    {
        string details = $"Title: {_trackTitle}\n" +
                         $"Author: {_trackAuthor}\n" +
                         $"Length: {_trackLength} seconds\n" +
                         $"Number of Comments: {GetCommentCount()}\n";

        foreach (var comment in _comments)
        {
            details += $"{comment.GetPerson()}: {comment.GetComment()}\n";
        }

        return details;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        
        Video video1 = new Video("Rises the Moon", "Author Liana Flores", 141);
        video1.AddComment(new Comment("User1 Tenrivera", "This songs feels like a hug"));
        video1.AddComment(new Comment("User2 Brian", "Very calming music"));
        video1.AddComment(new Comment("User3 Nate", "Songs that is forever in my life"));

        Video video2 = new Video("Kingston", "Author Faye Webster", 204);
        video2.AddComment(new Comment("User4 Joslin", "Found this in spotify!!"));
        video2.AddComment(new Comment("User5 Loving", "idk how to describe it but its like dreams."));
        video2.AddComment(new Comment("User6 Haya", "This song makes me want to fall in love..."));

        Video video3 = new Video("Show me how", "Author Men I trust", 222);
        video3.AddComment(new Comment("User Sara", "This is the most beautiful song ive heard"));
        video3.AddComment(new Comment("User Borg", "Lovely"));
        video3.AddComment(new Comment("User Susana", "She is so pretty"));

        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        
        foreach (var video in videos)
        {
            Console.WriteLine(video.DisplayVideoDetails());
            Console.WriteLine();
        }
    }
}
