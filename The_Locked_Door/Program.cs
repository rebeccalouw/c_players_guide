// See https://aka.ms/new-console-template for more information

// Boss Battle: The Locked Door

Console.WriteLine("Please choose a 5 digit code for the door.");
int startCode = Convert.ToInt32(Console.ReadLine());

var door = new Door(startCode);

Console.WriteLine("Action options: open, close, unlock, change code.");

while (true)
{
        Console.WriteLine($"Door is currently: {door.CurrentState}");
        string? action = Console.ReadLine().ToLower();

        switch (action)
        {
                case "open":
                        door.OpenDoor();
                        break;
                case "close":
                        door.CloseDoor();
                        break;
                case "lock":
                        door.LockDoor();
                        break;
                case "unlock":
                        Console.WriteLine("Please enter the code to unlock.");
                        int codeProvided = Convert.ToInt32(Console.ReadLine());
                        door.UnlockDoor(codeProvided);
                        break;
                case "change code":
                        Console.WriteLine("Please enter the code to change.");
                        int currentCode = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please enter new code.");
                        int newCode = Convert.ToInt32(Console.ReadLine());
                        door.ChangeCode(currentCode, newCode);
                        break;
                        
        }
}

public class Door
{ 
        public DoorState CurrentState { get; private set; } = DoorState.Closed;
        private int _code;

        public Door(int initialCode)
        {
                _code = initialCode;
        }

        public void CloseDoor()
        {
                if(CurrentState == DoorState.Open) CurrentState =  DoorState.Closed;
        }

        public void OpenDoor()
        {
                if(CurrentState == DoorState.Closed) CurrentState = DoorState.Open;
        }

        public void LockDoor()
        {
                if(CurrentState == DoorState.Closed) CurrentState = DoorState.Locked;
        }

        public void UnlockDoor(int code)
        {
                if(CurrentState == DoorState.Locked && code == _code) CurrentState = DoorState.Closed;
                else Console.WriteLine("Incorrect code, please try again.");
        }

        public void ChangeCode(int oldCode, int newCode)
        {
                if (oldCode == _code) _code = newCode;
                else Console.WriteLine("The existing code you entered was incorrect, please try again.");
        }

}

public enum DoorState { Open, Closed, Locked}