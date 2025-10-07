// See https://aka.ms/new-console-template for more information

// Boss Battle: The Card

using System.Drawing;

CardColor[] colorsArray = new CardColor[]
{
    CardColor.Red,
    CardColor.Green,
    CardColor.Blue,
    CardColor.Yellow,
};

CardRank[] ranksArray = new CardRank[]
{
    CardRank.One,
    CardRank.Two,
    CardRank.Three,
    CardRank.Four,
    CardRank.Five,
    CardRank.Six,
    CardRank.Seven,
    CardRank.Eight,
    CardRank.Nine,
    CardRank.Ten,
    CardRank.DollarSign,
    CardRank.Percent,
    CardRank.Ampersand,
    CardRank.Caret
};

foreach (CardColor color in colorsArray)
{
    foreach (CardRank rank in ranksArray)
    {
        Card card = new Card(rank, color);
        Console.WriteLine($"The {card.Color} {card.Rank}");
    }}

public class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }

    public Card(CardRank rank, CardColor color)
    {
        Rank = rank;
        Color = color;
    }

    public bool IsSymbol => Rank == CardRank.Ampersand || Rank == CardRank.Caret || Rank == CardRank.DollarSign ||
                            Rank == CardRank.Percent;

    public bool IsNumber => !IsSymbol;
}

public enum CardColor { Red, Green, Blue, Yellow };
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand };