using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Welcome to the program!");
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Please enter your favorite number: ");
        string favoriteNumberStr = Console.ReadLine();
        int favoriteNumber = int.Parse(favoriteNumberStr);

        PrintAnswers(name, favoriteNumber);
    }

    static void PrintAnswers(string name, int favoriteNumber) {
        Console.WriteLine($"Your name is: {name}, and your favorite number is: {favoriteNumber}.");
    }
}
