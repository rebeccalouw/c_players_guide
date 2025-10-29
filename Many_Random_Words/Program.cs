// See https://aka.ms/new-console-template for more information


// Challenge: Many Random Words

using System.Runtime.InteropServices.Marshalling;
List<Task> running = new List<Task>();

Console.WriteLine("Enter lowercase words to brute-force in parallel.");
Console.WriteLine("Type 'quit' to exit. Keep words short!");

while (true)
{
    Console.WriteLine("Word: ");
    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;
    
    string target = input.Trim().ToLowerInvariant();
    if (target == "quit")
        break;

    Task t = ProcessWordAsync(target);
    running.Add(t);
}

static async Task ProcessWordAsync(string word)
{
    DateTime start = DateTime.Now;
    int attempts = await RandomlyRecreateAsync(word);
    DateTime end = DateTime.Now;
    
    TimeSpan duration = end - start;
    
    Console.WriteLine($"\"{word}\" recreated.");
    Console.WriteLine($"{attempts} attempts");
    Console.WriteLine($"{duration.TotalSeconds:N2} seconds.\n");
}



static int RandomlyRecreate(string word)
{
    if (word.Length == 0) return 0;
    
    Random random = new Random();
    int attempts = 0;
    int n = word.Length;
    char[] buffer = new char[n];

    while (true)
    {
        attempts++;

        for (int i = 0; i < n; i++)
        {
            buffer[i] = (char)('a' + random.Next(0, 26));
        }
        
        string candidate = new string(buffer);
        if (candidate == word)
            return attempts;
    }
}

static Task<int> RandomlyRecreateAsync(string word)
{
    Task<int> task = Task.Run(() => RandomlyRecreate(word));
    return task;
}

