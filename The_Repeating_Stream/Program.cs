// See https://aka.ms/new-console-template for more information


// Challenge: The Repeating Stream

RecentNumbers recentNumbers = new RecentNumbers {MostRecent = -1, SecondMostRecent = -2};
Thread generatingThread = new Thread(GenerateNumbers);
generatingThread.Start(recentNumbers);

while (true)
{
    Console.ReadKey(false);

    bool isRepeated;
    lock(recentNumbers) 
        isRepeated = recentNumbers.MostRecent == recentNumbers.SecondMostRecent;
    
    if (isRepeated) Console.WriteLine("You spotted a duplicate number!");
    else Console.WriteLine("Ops, that's not a duplicate!");
}
void GenerateNumbers(object obj)
{
    if (obj == null || obj is not RecentNumbers) return;
    
    RecentNumbers recentNumbers = (RecentNumbers)obj;
    Random random = new Random();

    while (true)
    {
        int nextNumber = random.Next(10);

        lock (recentNumbers)
        {   
            recentNumbers.SecondMostRecent = recentNumbers.MostRecent;
            recentNumbers.MostRecent = nextNumber;
        }
        
        Console.WriteLine($"Generated number is: {nextNumber}");
        Thread.Sleep(1000);
    }
}

public class RecentNumbers
{
    public int MostRecent { get; set; }
    public int SecondMostRecent { get; set; }
}