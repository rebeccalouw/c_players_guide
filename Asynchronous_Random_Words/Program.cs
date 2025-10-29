// See https://aka.ms/new-console-template for more information

// Challenge: Asynchronous Random Words

using System.Runtime.InteropServices.Marshalling;

Console.Write("Enter a lowecase word, but keep it short! ");
string? input = Console.ReadLine();
if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("You entered an invalid word. Exiting...");
    return;
}

string target = input.Trim().ToLowerInvariant();

Console.WriteLine($"Reacreating \"{target}\" randomly, please hold...");

DateTime start = DateTime.Now;
int attempts = await RandomlyRecreateAsync(target);
DateTime end = DateTime.Now;

TimeSpan duration = end - start;


Console.WriteLine($"\nDone!");
Console.WriteLine($"Word:        {target}");
Console.WriteLine($"Attempts:    {attempts:N0}");
Console.WriteLine($"Elapsed:     {duration:g} ({duration.TotalSeconds:N2} seconds)");


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


