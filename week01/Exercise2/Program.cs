// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello World! This is the Exercise2 Project.");
//     }
// }

using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter;

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Here is your grade: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You did great.");
        }
        else
        {
            Console.WriteLine("Keep working hard, You will do better next time.");
        }
    }
}
