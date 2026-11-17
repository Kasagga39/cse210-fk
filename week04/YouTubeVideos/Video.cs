using System;
using System.Collections.Generic;

public class Video
{
    // Private member variables (underscoreCamelCase)
    private string _title;
    private string _author;
    private int _length; // seconds
    private List<Comment> _comments;

    // Constructor
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Getters
    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _length;
    }

    // Add a comment to this video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Required: return the number of comments directly from storage
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Return the comment list for iteration
    public List<Comment> GetComments()
    {
        return _comments;
    }

    // Convenience method to display everything about this video
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title:  {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }
    }
}