using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_1;

public static class CardValidator
{
    private const int AmericanExpressCardNumbersCount = 15;
    private const int MasterCardCardNumbersCount = 16;
    private static readonly int[] VisaCardNumbersCount = new int[]{ 13, 16 };

    private static readonly string[] VisaAllowedStarts = new string[] { "4" };
    private static readonly string[] MasterCardAllowedStarts = new string[] { "51", "52", "53", "54", "55" };
    private static readonly string[] AmericanExpressAllowedStarts = new string[] { "34", "37" };
    public static void ValidateCard(CardModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        NumberCheckForType(model);

        if (!CrcCheck(model.Number))
        {
            throw new Exception($"Card control summ is wrong for card: {model.Number}");
        }
    }
    private static void NumberCheckForType(CardModel model)
    {
        if (model.Type == CardType.Visa)
        {
            ValidateNumbersCount(model.Number, VisaCardNumbersCount);

            ValidateStartNumber(model.Number, VisaAllowedStarts);
        }
        else if (model.Type == CardType.AmericanExpress)
        {
            ValidateNumbersCount(model.Number, AmericanExpressCardNumbersCount);

            ValidateStartNumber(model.Number, AmericanExpressAllowedStarts);
        }
        else if (model.Type == CardType.MasterCard) 
        {
            ValidateNumbersCount(model.Number, MasterCardCardNumbersCount);

            ValidateStartNumber(model.Number, MasterCardAllowedStarts);
        }
    }

    private static void ValidateNumbersCount(string number, params int[] expectedCounts) 
    {
        if (!expectedCounts.Contains(number.Length))
        {
            throw new Exception($"Card numbers count  is wrong ({number.Length})");
        }
    }
    private static void ValidateStartNumber(string number, params string[] expectedStarts)
    {
        if (!expectedStarts.Any(x => number.StartsWith(x)))
        {
            throw new Exception($"Wrong start of card numbers");
        }
    }
    
    private static bool CrcCheck(string data)
    {
        int sum = 0;
        bool isAlternateDigit = false;

        // Start from the rightmost digit and iterate over all digits
        for (int i = data.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(data[i]))
            {
                throw new Exception($"Wrong char {data[i]} in card number {data}");
            }
            int digit = Convert.ToInt32(data[i].ToString());

            // Double the value of every alternate digit
            if (isAlternateDigit)
            {
                digit *= 2;

                // If the doubled digit is greater than 9, subtract 9 from it
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            isAlternateDigit = !isAlternateDigit;
        }

        // The credit card number is valid if the sum is divisible by 10
        return sum % 10 == 0;
    }
}


