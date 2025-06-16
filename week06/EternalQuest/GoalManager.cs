using System.Text;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine($"\nYou have {_score} points.\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid input."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (choice == 1)
            _goals.Add(new SimpleGoal(name, description, points));
        else if (choice == 2)
            _goals.Add(new EternalGoal(name, description, points));
        else if (choice == 3)
        {
            Console.Write("Target times: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    private void RecordEvent()
    {
        Console.WriteLine("Select the goal you accomplished:");
        ListGoals();
        Console.Write("Choice: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += _goals[index].GetPoints();
        }
    }

    private void SaveGoals()
    {
        Console.Write("Filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
                writer.WriteLine(goal.GetStringRepresentation());
        }
        Console.WriteLine("Saved successfully!");
    }

    private void LoadGoals()
    {
        Console.Write("Filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();
            foreach (string line in lines.Skip(1))
            {
                string[] parts = line.Split(':');
                string type = parts[0];
                string[] data = parts[1].Split('|');

                if (type == "SimpleGoal")
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2])) { });
                else if (type == "EternalGoal")
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                else if (type == "ChecklistGoal")
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3])));
            }
            Console.WriteLine("Loaded successfully!");
        }
        else Console.WriteLine("File not found.");
    }
}
