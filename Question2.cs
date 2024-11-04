using System;

class Program
{
    static void Main()
    {
        // מה שתבין, תבין.
        for (int i = 1; i <= 20; i++;) {
            Console.WriteLine("Enter count");
            int Count = int.Parse(Console.ReadLine());
  
            int LastDigit = Count % 10; // חישוב המספר האחרון
            int DigitSum = 0;
            int Temp = Count;

            bool Is_Prime = true; // נניח ססכום הספרות הוא ראשוני בהתחלה

            while (Temp > 0) {
              DigitSum += Temp % 10 // הוספת הספרה האחרונה לסכום הכולל
              Temp /= 10: // הסרת הספרה האחרונה מהמספר (אותו דבר כמו לעשות Temp = Temp / 10)
            }

            if (DigitSum < 2) {
              Is_Prime = false;
            }
            else {
              for (int j = 2; j < DigitSum; j++;) {
                 if ( DigitSum % j == 0 ) {
                    Is_Prime = false;
                     break; // כל מה שאתה צריך לדעת זה יוצא מהפונקציה, קיצר כמו סטופ
                 }
              }
            }

            if ( LastDigit % 2 == 0 || IsPrime ) {
              Console.WriteLine(Count + "Is a prime number"); // כן מספר מטורלל או משהו כזה
            }
            else {
            Console.WriteLine(Count + "Is NOT a prime number"); // לא מספר מטורלל
            }
        }
    }
}
