// See https://aka.ms/new-console-template for more information

// Challenge: The Variable Shop

// Numeric
sbyte tinySigned = -100;
byte tinyUnsigned = 200;
short shortNum = -12345;
ushort ushortNum = 12345;
int wholeNum = 35;
uint uwholeNum = 35u;
long bigNum = 3_000_000_000L;
ulong ubigNum  = 4_000_000_000UL;

float ratio = 3.5623f;
double precise = 2.7182853798d;
decimal stockPrice = 13.8798857m;

//Non numeric
char initial = 'R';
string greeting = "Hello friend!";
bool isSunny = true;

Console.WriteLine("sbyte: " + tinySigned);
Console.WriteLine("byte: " + tinyUnsigned);
Console.WriteLine("short: " + shortNum);
Console.WriteLine("ushort: " + ushortNum);
Console.WriteLine("int: " + wholeNum);
Console.WriteLine("uint: " + uwholeNum);
Console.WriteLine("long: " + bigNum);
Console.WriteLine("ulong: " + ubigNum);
Console.WriteLine("float: " + ratio);
Console.WriteLine("double: " + precise);
Console.WriteLine("decimal: " + stockPrice);
Console.WriteLine("char: " + initial);
Console.WriteLine("string: " + greeting);
Console.WriteLine("bool: " + isSunny);


//The Variable Shop Returns

tinySigned = -90;
tinyUnsigned = 220;
shortNum = -12300;
ushortNum = 23456;
wholeNum = 40;
uwholeNum = 40u;
bigNum = 4_000_000_000L;
ubigNum  = 5_000_000_000UL;
ratio = 5.5623f;
precise = 3.7182853798d;
stockPrice = 15.8798857m;
initial = 'L';
greeting = "Hello, dear friend!";
isSunny = false;

Console.WriteLine("new sbyte: " + tinySigned);
Console.WriteLine("new byte: " + tinyUnsigned);
Console.WriteLine("new short: " + shortNum);
Console.WriteLine("new ushort: " + ushortNum);
Console.WriteLine("new int: " + wholeNum);
Console.WriteLine("new uint: " + uwholeNum);
Console.WriteLine("new long: " + bigNum);
Console.WriteLine("new ulong: " + ubigNum);
Console.WriteLine("new float: " + ratio);
Console.WriteLine("new double: " + precise);
Console.WriteLine("new decimal: " + stockPrice);
Console.WriteLine("new char: " + initial);
Console.WriteLine("new string: " + greeting);
Console.WriteLine("new bool: " + isSunny);