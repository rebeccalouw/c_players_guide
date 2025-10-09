// See https://aka.ms/new-console-template for more information

// Challenge: The Old Robot

Robot robot = new Robot();

for (int i = 0; i < robot.Commands.Length; i++)
{
    string? choice = Console.ReadLine();
    RobotCommand newCommand = choice switch
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


public class OffCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = false;
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = true;
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y++;
    }
}

public class SouthCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class EastCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X++;
    }
}

public class WestCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X--;
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}