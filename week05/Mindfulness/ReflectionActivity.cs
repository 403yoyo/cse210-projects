using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
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
        "What made this time different from other times?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself through this experience?",
        "How can you apply this experience in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity() 
        : base("Reflection Activity", "This activity will help you reflect on times you showed strength and resilience, helping you recognize your power.")
    {
    }

    public override void RunActivity()
    {
        StartActivity();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Console.WriteLine("\n" + _prompts[_random.Next(_prompts.Count)]);
        ShowSpinner(3);

        while (DateTime.Now < endTime)
        {
            string question = _questions[_random.Next(_questions.Count)];
            Console.WriteLine($"\n> {question}");
            ShowSpinner(4);
        }

        EndActivity();
    }
}
