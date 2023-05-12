using System;

public class JournalForm
{
    public string _entryNumber = "";
    public string _dateTime = "";
    public string _promptGenerator = "";
    public string _journalForm = "";
    public string _journalFile = "";

    public JournalForm()
    {

    }

    public void Display()
    {
        Console.WriteLine($"\n#: {_entryNumber}");
        Console.WriteLine($"Date: {_dateTime}");
        Console.WriteLine($"Prompt: {_promptGenerator}");
        Console.WriteLine($"Entry: {_journalForm}");
    }
}



