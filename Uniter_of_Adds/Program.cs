// See https://aka.ms/new-console-template for more information

// Challenge: Uniter of Adds

Console.WriteLine($"int: 1 + 2 = {Adds.Add(1, 2)}");
Console.WriteLine($"double: 1.5 + 2.2 = {Adds.Add(1.5, 2.2)}");
Console.WriteLine($"string: abc + def = {Adds.Add("abc", "def")}");
Console.WriteLine($"DateTime and TimeSpan: 1 + 2 = {Adds.Add(DateTime.Now, TimeSpan.FromDays(1))}");

public static class Adds
{
    public static dynamic Add(dynamic a, dynamic b) => a + b;
}



