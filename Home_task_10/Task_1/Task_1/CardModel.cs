namespace Task_1;

public enum CardType
{
    MasterCard,
    AmericanExpress,
    Visa
}

public class CardModel
{
    public CardType Type { get; set; }
    public string Number { get; set; } = null!;
}