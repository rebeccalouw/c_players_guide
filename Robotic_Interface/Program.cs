// See https://aka.ms/new-console-template for more information

// Challenge: Robotic Interface

Robot robot = new Robot();

Console.WriteLine("Hello, what should the robot do?");
Console.WriteLine("Enter a command: on, off, north, south, east, west.");

for (int i = 0; i < robot.Commands.Length; i++)
{   
    Console.WriteLine($"Command {i + 1}:");
    string? choice = Console.ReadLine();
    IRobotCommand newCommand = choice switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand()
    };
    
    robot.Commands[i] = newCommand;
}

robot.Run();
public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
        Console.WriteLine("Robot is now turned off.");
    }
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
        Console.WriteLine("Robot is powered.");
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : IRobotCommand {
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class EastCommand : IRobotCommand {
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}

public class WestCommand : IRobotCommand {
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}