// See https://aka.ms/new-console-template for more information

// Challenge: Excepti's Game

string currentPlayer = "Player 1";

try
{
    int badCookie = new Random().Next(10);
    List<int> previousGuesses = new List<int>();
    
    Console.WriteLine(
        "There are nine delicious chocolate chip cookies around, but also one oatmeal raising cookie.");
    Console.WriteLine("The player that picks the bad cookie is out!");

    while (true)
    {
        int choice = -1;
        bool previouslyGuessed = true;
        
        do
        {
            Console.WriteLine($"{currentPlayer}, choose a number between 1 and 9.");
            
            choice = Convert.ToInt32(Console.ReadLine());
            previouslyGuessed = previousGuesses.Contains(choice);
            
            if (previouslyGuessed) Console.WriteLine("That number has been guessed before.");
        } while (previouslyGuessed == true);
        
        if (choice == badCookie) throw new Exception();
        
        currentPlayer = currentPlayer == "Player 1" ? "Player 2" : "Player 1";
        previousGuesses.Add(choice);
    }
    
}
catch (Exception)
{   
    string winner = currentPlayer == "Player 1" ? "Player 2" : "Player 1";
    Console.WriteLine($"Oh no, you picked the bad cookie, you lose! {winner} is the winner!");
}


// If it wasn't necessary to use the exception because of the exercise instructions, I'd have handled the handled everything with if statements