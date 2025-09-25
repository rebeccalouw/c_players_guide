// See https://aka.ms/new-console-template for more information

// Challenge: The Laws of Freach

// Minimum value
int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };

int currentSmallest = int.MaxValue; 

foreach (int item in array)
{
    if (item < currentSmallest)
        currentSmallest = item;
}
Console.WriteLine(currentSmallest);


// Average

int[] array2 = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int total = 0;

foreach (int item in array2)
    total += item;

float average = (float)total / array2.Length;
Console.WriteLine(average);