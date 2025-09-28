// See https://aka.ms/new-console-template for more information

// Challenge: Simula’s Test

BoxState state = BoxState.Locked;


while (true)
{
    Console.WriteLine($"The chest is {state}. What do you want to do?");
    Console.WriteLine("lock / unlock / open / close: ");
    string input = Console.ReadLine().ToLower();

    switch (state)
    {
        case BoxState.Locked:
            if (input == "unlock")
            {
                state = BoxState.Closed;
                Console.WriteLine("You unlocked the chest.");
            }
            else
            {
                Console.WriteLine("Nothing happens.");
            }

            break;
        
        case BoxState.Closed:
            if (input == "open")
            {
                state = BoxState.Open;
                Console.WriteLine("You opened the chest.");
            }
            else if (input == "lock")
            {
                state = BoxState.Locked;
                Console.WriteLine("You locked the chest.");
            }
            else
            {
                Console.WriteLine("Nothing happens.");
            }

            break;
        case BoxState.Open:
            if (input == "close")
            {
                state = BoxState.Closed;
                Console.WriteLine("You closed the chest.");
            }
            else
            {
                Console.WriteLine("Nothing happens.");
            }

            break;
    }
}

enum BoxState { Open, Closed, Locked}
