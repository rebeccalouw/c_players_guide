// See https://aka.ms/new-console-template for more information

// Challenge: The Replicator of D’To

int[] artifacts = new int[5];

for (int index = 0; index < artifacts.Length; index++)
{
    Console.Write("Please enter a number: ");
    artifacts[index] = Convert.ToInt32(Console.ReadLine());
}


int[] artifactsCopy = new int[artifacts.Length];

for (int index = 0; index < artifacts.Length; index++)
{
    artifactsCopy[index] = artifacts[index];
}

Console.WriteLine("Original artifacts array: ");
for (int i = 0; i < artifacts.Length; i++)
{
    Console.WriteLine($"Item {i + 1} : {artifacts[i]}");
}

Console.WriteLine("Copied artifacts array: ");
for (int i = 0; i < artifactsCopy.Length; i++)
{
    Console.WriteLine($"Item {i + 1}: {artifactsCopy[i]}");
}

