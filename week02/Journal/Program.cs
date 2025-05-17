// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello World! This is the Journal Project.");
//     }
// }


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var random = new Random();
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response);
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
