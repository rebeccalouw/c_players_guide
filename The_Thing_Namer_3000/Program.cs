// See https://aka.ms/new-console-template for more information

// Challenge: The Thing Namer 3000
Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); // The thing they are talking about 
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); /* description of the object */
string c = "of Doom"; // more details
string d = "3000"; // maybe the model?
// Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!"); --- no need for the " of " 
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");
