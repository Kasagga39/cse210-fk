using System;

public class Comment
{
    // Private member variables (underscoreCamelCase)
    private string _commenterName;
    private string _commentText;

    // Constructor (TitleCase class name, camelCase parameters)
    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Getters (TitleCase methods)
    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetCommentText()
    {
        return _commentText;
    }

    // Display helper
    public void DisplayComment()
    {
        Console.WriteLine($"  - {_commenterName}: {_commentText}");
    }
}