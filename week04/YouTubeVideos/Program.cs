using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List to hold all videos
        List<Video> videos = new List<Video>();

        // ---------- Video 1 ----------
        Video video1 = new Video(
            "C# Abstraction Explained",
            "CodeWithMosh",
            845);
        video1.AddComment(new Comment("Alice", "Great explanation of abstraction!"));
        video1.AddComment(new Comment("Brian", "This finally made sense to me."));
        video1.AddComment(new Comment("Chloe", "Can you do a follow-up on encapsulation?"));
        video1.AddComment(new Comment("Diego", "Loved the real-world examples."));
        videos.Add(video1);

        // ---------- Video 2 ----------
        Video video2 = new Video(
            "Top 10 Product Placements in YouTube Videos",
            "MarketingMinute",
            612);
        video2.AddComment(new Comment("Emma", "Number 7 was my favorite!"));
        video2.AddComment(new Comment("Farhan", "Interesting how subtle some placements are."));
        video2.AddComment(new Comment("Grace", "I never noticed half of these."));
        videos.Add(video2);

        // ---------- Video 3 ----------
        Video video3 = new Video(
            "How to Build Classes in C#",
            "ProgrammingWithClasses",
            1320);
        video3.AddComment(new Comment("Henry", "The diagram at 5:30 really helped."));
        video3.AddComment(new Comment("Isabel", "Clear and concise, thank you."));
        video3.AddComment(new Comment("Jamal", "Subscribed!"));
        video3.AddComment(new Comment("Kira", "Please cover inheritance next."));
        videos.Add(video3);

        // ---------- Video 4 ----------
        Video video4 = new Video(
            "Behind the Scenes: Product Awareness Study",
            "BrandWatch",
            455);
        video4.AddComment(new Comment("Liam", "Fascinating data on viewer retention."));
        video4.AddComment(new Comment("Maya", "Would love to see the raw numbers."));
        video4.AddComment(new Comment("Noah", "Shared this with my team."));
        videos.Add(video4);

        // ---------- Iterate and display all videos ----------
        foreach (Video video in videos)
        {
            Console.WriteLine("==========================================");
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}