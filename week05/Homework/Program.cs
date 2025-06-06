using System;

class Program
{
    static void Main(string[] args)
    {

        Assignment assignment = new Assignment("Chukwuemeka Ohenhen", "Addition");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        MathAssignment mathAssignment = new MathAssignment(
            "Aisha Okoro", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writingAssignment = new WritingAssignment(
            "Emeka Nwachukwu", "Chinese History", "How the great wall came about");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
