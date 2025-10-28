// See https://aka.ms/new-console-template for more information

// Challenge: The Three Lenses

int[] data = { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

foreach (int number in Procedural(data))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in QuerySyntax(data))
    Console.Write($"{number} ");
Console.WriteLine();

foreach (int number in MethodSyntax(data))
    Console.Write($"{number} ");
Console.WriteLine();


IEnumerable<int> Procedural(int[] nums)
{
    var evens = new List<int>();
    foreach (var n in nums)
        if (n % 2 == 0) evens.Add(n);
    
    evens.Sort();

    for (int i = 0; i < evens.Count; i++)
        evens[i] = evens[i] * 2;
    
    return evens;
}

IEnumerable<int> QuerySyntax(int[] nums)
{
    return from n in nums
        where n % 2 == 0
        orderby n
        select n * 2;
}

IEnumerable<int> MethodSyntax(int[] nums)
{
    return nums
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n * 2);
}
