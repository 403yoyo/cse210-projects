using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() 
        : base("Listing Activity", "This activity helps you reflect on the good things in your life by listing as many as you can.")
    {
    }

    public override void RunActivity()
    {
        StartActivity();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Console.WriteLine("\n" + _prompts[_random.Next(_prompts.Count)]);
        Console.WriteLine("\nYou have a few seconds to think before starting...");
        ShowCountdown(5);

        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        EndActivity();
    }
}
