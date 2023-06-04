
namespace Task_1;

public static class CardParser
{
    public static CardModel ParseCardModel(string strCardInfo)
    {
        
        var infoParts = strCardInfo.Split('#', StringSplitOptions.RemoveEmptyEntries);
        var cardModel = new CardModel() { Type = ParseType(infoParts[0]), Number = ParseNumber(infoParts[1])};


        return cardModel;
    } 
    private static string ParseNumber(string strNumber)
    {
        return strNumber[(strNumber.IndexOf('“') + 1)..strNumber.IndexOf('”')];
    }

    //use to lower and remove all spaces for awoid wrong naming parsing
    private static CardType ParseType(string strType) => strType.Replace(" ", "").ToLower() switch
    {
        "visa" => CardType.Visa,
        "mastercard" => CardType.MasterCard,
        "americanexpress" => CardType.AmericanExpress,
        _ => throw new NotImplementedException(),
    };
}
