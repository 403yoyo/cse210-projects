// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
//     }
// }


using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string CommentText
    {
        get { return _commentText; }
    }
}

public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public string Title
    {
        get { return _title; }
    }

    public string Author
    {
        get { return _author; }
    }

    public int LengthInSeconds
    {
        get { return _lengthInSeconds; }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Reviewing the Xiaomi 15", "Phones review", 600);
        Video video2 = new Video("Funny Cat Compilation", "CatLover", 300);
        Video video3 = new Video("Learn the basics of C#", "yoyo", 900);

        video1.AddComment(new Comment("Osaigbovo", "Great review, very helpful!"));
        video1.AddComment(new Comment("Grace", "I just love Xiaomi products."));
        video1.AddComment(new Comment("Oshoke", "Thanks for the info."));

        video2.AddComment(new Comment("Idahosa", "Cats are the best!"));
        video2.AddComment(new Comment("Obazee", "Haha so funny!"));
        video2.AddComment(new Comment("James", "I wasn't sure I love cats, until now"));

        video3.AddComment(new Comment("Udeh", "Thanks for the clear explanation."));
        video3.AddComment(new Comment("Adebayo", "This helped me a lot."));
        video3.AddComment(new Comment("Peace", "Looking forward to more tutorials."));
        video3.AddComment(new Comment("Jane", "Please do advanced topics next."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment.CommenterName}: {comment.CommentText}");
            }
            Console.WriteLine();
        }
    }
}
