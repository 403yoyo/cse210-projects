using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(string prompt, string response)
    {
        _entries.Add(new Entry
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd"),
            Prompt = prompt,
            Response = response
        });
    }

    public void DisplayJournal()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new Entry
                {
                    Date = parts[0],
                    Prompt = parts[1],
                    Response = parts[2]
                });
            }
        }
    }
}
