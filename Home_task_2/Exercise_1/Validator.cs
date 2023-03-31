namespace Exercise_1;

public class Validator
{
    public static bool ValidateNumber(double num)
    {
        if (num > 0)
        {
            return true;
        }
        throw new ArgumentException("Значення повинне бути бiльше 0!");
    }

    public static bool ValidateEfficiency(int percentage)
    {
        if (percentage > 0 & percentage < 100)
        {
            return true;
        }
        throw new ArgumentException("Значення ККД повинно бути в межах від 0 до 100");
    }
}