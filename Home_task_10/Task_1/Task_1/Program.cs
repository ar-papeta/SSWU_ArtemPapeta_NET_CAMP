
using Task_1;

string[] strCards = 
{
    "# American   Express # card_number = “378282246310005”",
    "# MasterCard # card_number = “5555555555554444”",
    "# Visa # card_number = “4003789100205381”",
    "# Visa # card_number = “4003789100209999”",
    "# Visa # card_number = “400378^919999”"
};


foreach (var strCard in strCards)
{
    try
    {
        var card = CardParser.ParseCardModel(strCard);
        CardValidator.ValidateCard(card);
        Console.WriteLine($"Card: {card.Number} is valid for type {card.Type}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

    


