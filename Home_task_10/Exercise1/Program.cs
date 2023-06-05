namespace Exercise1;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Введiть номер картки:");
        string cardNumber = Console.ReadLine();
        //string cardNumber = "578289246310005"; // Приклад номеру картки American Express

        CardType cardType = CreditCardValidator.ValidateCreditCard(cardNumber);
        
        if (cardType != CardType.Unknown)
        {
            bool isValid = CreditCardValidator.CheckLuhnAlgorithm(cardNumber);

            if (isValid)
            {
                Console.WriteLine($"Номер картки {cardNumber} є коректним {cardType} номером.");
            }
            else
            {
                Console.WriteLine($"Номер картки {cardNumber} не пройшов валiдацiю.");
            }
        }
        else
        {
            Console.WriteLine($"Номер картки {cardNumber} не вiдповiдає жоднiй пiдтримуванiй платiжнiй системi.");
        }
    }
}