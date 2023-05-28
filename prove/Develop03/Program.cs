using System;
using System.Text.Json;
using System.Text.Json.Serialization;



class Program
{
    /// <summary>
    /// The function initializes objects and displays a welcome message for a Scripture Memorizer App.
    /// </summary>
    /// <param name="args">args is an array of strings that contains the command-line arguments passed
    /// to the program. It can be used to pass arguments to the program when it is executed from the
    /// command line.</param>
    static void Main(string[] args)
    {
        
        Console.Clear();
        Reference reference = new Reference();
        reference.LoadReference();
        Scripture scripture = new Scripture();
        scripture.LoadScriptures();
        Word word = new Word();

        Console.Write("\n**** Welcome to the Scripture Memorizer App ****\n");

        int userChoice = 0;
        

       /* This code block is the main loop of the program. It repeatedly prompts the user for a choice
       of action until the user enters 3 to quit. The `UserChoice()` method is called to get the
       user's choice, and then a switch statement is used to execute the appropriate action based on
       the user's choice. If the user enters an invalid choice, a message is displayed to inform
       them of the error. */
        while (userChoice != 3)
        {
            
            userChoice = UserChoice();

            switch (userChoice)
            {
                case 1:
                    reference.ReferenceDisplay();

                    break;
                case 2:
                    string script = scripture.RandomScripture();
                    string ref1 = reference.GetReference(scripture);
                    word.GetRenderedText(scripture);
                    word.GetRenderedRef(scripture);
                    

                    while (word._hidden.Count < word._result.Length)
                    {
                        word.Show(ref1);
                        word.GetReadKey();
                    }
                    word.Show(ref1);
                    break;
                case 3:
                    Console.WriteLine("\n*** Thanks for playing! ***\n");
                    break;
                default:
                    Console.WriteLine($"\nSorry the option you entered is not valid.");
                    break;
            }
        }

    }

    static int UserChoice()
    
    {
        Reference reference = new Reference();

        string choices = $@"
===========================================
Please select one of the following choices:
1. Display all availble scriptures references
2. Randomly select scripture to work on
Q. Quit
===========================================
What would you like to do?  ";

       /* This code block defines a method called `UserChoice()` that prompts the user to select an
       option from a menu of choices. It displays the menu using `Console.Write(choices)` and then
       reads the user's input using `Console.ReadLine()`. The user's input is then converted to
       lowercase using `userInput.ToLower()`. */
        Console.Write(choices);

        string userInput = Console.ReadLine();
        userInput.ToLower();
        int userChoice = 0;
        
        try
        {
            if (userInput == "q")
            {
                userInput = "3";
            }
            userChoice = int.Parse(userInput);
        }
        catch (FormatException)
        {
            userChoice = 0;
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"Unexpected error:  {exception.Message}");
        }
        return userChoice;
    }


}
