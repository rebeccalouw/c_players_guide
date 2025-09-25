// See https://aka.ms/new-console-template for more information

// Challenge: The Four Sisters and the Duckbear

Console.Write("Enter the number of chocolate eggs gathered today: ");
int totalNumberOfEgss = Convert.ToInt32(Console.ReadLine());

int eachSister = totalNumberOfEgss / 4;
int duckbear =  totalNumberOfEgss % 4;

Console.WriteLine("Today each sister gets: " + eachSister + " and the Duckbear gets: " + duckbear);

// If the total amount of eggs is 6, 7 or 11, Duckbear gets more than each sister
// Possible remainders are 1, 2 and 3
// Total 6: each sister gets 1 and duckbear gets 2
// Total 7: each sister gets 1 and duckbear gets 3
// Total 11: each sister gets 2 and duckbear gets 3