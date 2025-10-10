// See https://aka.ms/new-console-template for more information

// Challenge: War Preparations

Sword basicSword = new Sword(Material.Iron, Gemstone.None, 80, 45);
Sword shinySword = basicSword with { SwordMaterial = Material.Binarium, Gemstone = Gemstone.Emerald };
Sword lightSword = basicSword with { SwordMaterial = Material.Wood, Length = 65 };

Console.WriteLine(basicSword);
Console.WriteLine(shinySword);
Console.WriteLine(lightSword);


public record Sword(Material SwordMaterial, Gemstone Gemstone, float Length, float CrossguardWidth );

public enum Material { Wood, Bronze, Iron, Steel, Binarium };
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None };