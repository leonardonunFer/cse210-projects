using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Journal
{
    
    public List<JournalForm> _journal = new List<JournalForm>();
    // private string fileName = "MyJournal.txt";
    private string _userFileName;

    public Journal()
    {

    }

    public void Display()
    {
        Console.WriteLine("\n---------- Journal Entries ----------");
        foreach (JournalForm journalForm in _journal)
        {
            journalForm.Display();
        }
        Console.WriteLine("\n_____________ The End ____________");
    }

    public void CreateJournalFile()
    {
        Console.Write("What your file name? ");
        string userInput = Console.ReadLine();
        _userFileName = userInput + ".txt";

        if (!File.Exists(_userFileName))
        {
            File.CreateText(_userFileName);
            Console.Write($"\n*** {_userFileName} has been created! ***\n");
            Console.Write("***  Your journal entries have been saved. ***\n");
            SaveJournalFile(_userFileName);
            CreateJSON(userInput);
    }
    else
        {
            Console.Write($"\n*** {_userFileName} already exits. ***\n");
            Console.Write("***  Your journal entries have been added. ***\n");
            AppendJournalFile(_userFileName);
        }
    }

    public void SaveJournalFile(string _userFileName)
    {
        StreamWriter streamWriter = new StreamWriter(_userFileName);
        using (StreamWriter outputFile = streamWriter)
        {
            foreach (JournalForm journalForm in _journal)
            {
                outputFile.WriteLine($"{journalForm._entryNumber}; {journalForm._dateTime}; {journalForm._promptGenerator}; {journalForm._journalForm}");
            }
        }
    }
    
    public void AppendJournalFile(string _userFileName)
    {
        using (StreamWriter outputFile = new StreamWriter(_userFileName, append: true))
        {
            foreach (JournalForm journalForm in _journal)
            {
                outputFile.WriteLine($"{journalForm._entryNumber}; {journalForm._dateTime}; {journalForm._promptGenerator}; {journalForm._journalForm}");
            }
        }
    }

    public void LoadJournalFile()
    {
        Console.Write("What your file name? ");
        string userInput = Console.ReadLine();
        _userFileName = userInput + ".txt";

        if (File.Exists(_userFileName))
        {
            List<string> readText = File.ReadAllLines(_userFileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            foreach (string line in readText)
            {
                string[] entries = line.Split("; ");

                JournalForm entry = new JournalForm();

                entry._entryNumber = entries[0];
                entry._dateTime = entries[1];
                entry._promptGenerator = entries[2];
                entry._journalForm = entries[3];

                _journal.Add(entry);
            }        
        }   

    }

    public void CreateJSON(string userInput)
    {
        string fileName = userInput + ".json";
        List<Item> _data = new List<Item>();

        foreach (JournalForm journalForm in _journal)
        {
            _data.Add(new Item()
            {
                ID = journalForm._entryNumber,
                Date = journalForm._dateTime,
                Prompt = journalForm._promptGenerator,
                Entry = journalForm._journalForm
            });
            
        }
        string json = JsonSerializer.Serialize(_data);
        File.WriteAllText(fileName, json);
    }

}