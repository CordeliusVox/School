using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter First Number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter Second Number: ");
        int num2 = int.Parse(Console.ReadLine());

        while (num1 != num2) {
          if (num1 > num2) {
            num1 -= nm2;
          }
          else {
            num2 -= num1;
          }
        }

        Console.WriteLine("המכנה המשותף המקסימלי הוא: " + num1);
    }
}
