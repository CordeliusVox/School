using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int Num = int.Parse(Console.ReadLine());

        int Sum = 0;

        for (int i = 1; i <= num / 2; i++)
        {
            if (num % i == 0)
            {
                sum += i;
            }
        }

        if (sum < num) {
            Console.WriteLine(num + " הוא מספר מיוחד");
        }
        else {
            Console.WriteLine(num + " אינו מספר מיוחד");
        }

      // קיצר בודק אם המספר הוא מיוחד
    }
}
