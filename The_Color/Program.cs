// See https://aka.ms/new-console-template for more information

// Boss Battle: The Color

Color turquoise = new Color(64, 224, 208);
Color purple = Color.CreateColorPurple();

Console.WriteLine($"Turquoise: R={turquoise.R}, G={turquoise.G}, B={turquoise.B}");
Console.WriteLine($"Purple: R={purple.R}, G={purple.G}, B={purple.B}");

public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }
    
    public Color() : this(0, 0, 0) { }
    
    public static Color CreateColorWhite() => new Color(255, 255, 255);
    public static Color CreateColorBlack() => new Color(0, 0, 0);
    public static Color CreateColorRed() => new Color(255, 0, 0);
    public static Color CreateColorOrange() => new Color(255, 165, 0);
    public static Color CreateColorYellow() => new Color(255, 255, 0);
    public static Color CreateColorGreen() => new Color(0, 128, 0);
    public static Color CreateColorBlue() => new Color(0, 0, 255);
    public static Color CreateColorPurple() => new Color(128, 0, 128);
}