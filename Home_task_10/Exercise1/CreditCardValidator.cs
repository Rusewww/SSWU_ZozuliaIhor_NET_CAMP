namespace Exercise1;

public class CreditCardValidator
{
    public static CardType ValidateCreditCard(string cardNumber)
    {
        cardNumber = cardNumber.Replace(" ", ""); // Видаляємо пробіли з номеру картки

        if (IsAmericanExpress(cardNumber))
        {
            return CardType.AmericanExpress;
        }
        else if (IsMasterCard(cardNumber))
        {
            return CardType.MasterCard;
        }
        else if (IsVisa(cardNumber))
        {
            return CardType.Visa;
        }
        else
        {
            return CardType.Unknown;
        }
    }

    private static bool IsAmericanExpress(string cardNumber)
    {
        return cardNumber.Length == 15 && (cardNumber.StartsWith("34") || cardNumber.StartsWith("37"));
    }

    private static bool IsMasterCard(string cardNumber)
    {
        return cardNumber.Length == 16 && (cardNumber.StartsWith("51") || cardNumber.StartsWith("52") || cardNumber.StartsWith("53") || cardNumber.StartsWith("54") || cardNumber.StartsWith("55"));
    }

    private static bool IsVisa(string cardNumber)
    {
        int length = cardNumber.Length;
        return (length == 13 || length == 16) && cardNumber.StartsWith("4");
    }

    public static bool CheckLuhnAlgorithm(string cardNumber)
    {
        cardNumber = cardNumber.Replace(" ", ""); // Видаляємо пробіли з номеру картки

        int sum = 0;
        bool isSecondDigit = false;

        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = cardNumber[i] - '0';

            if (isSecondDigit)
            {
                digit *= 2;

                if (digit > 9)
                {
                    digit = digit % 10 + 1;
                }
            }

            sum += digit;
            isSecondDigit = !isSecondDigit;
        }

        return sum % 10 == 0;
    }
}