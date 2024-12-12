int Days = 1;
int Max = 0; // Maximum improvement value
int Max_Day = 0; // Day with the maximum improvement

int Good_Sum = 0; // Sum of differences for good days
int Bad_Sum = 0; // Sum of differences for bad days

Console.WriteLine("Enter the seconds for day: " + Days);
int num = int.Parse(Console.ReadLine());
if (num == 0)
{
    Console.WriteLine("No days recorded.");
    return;
}

int prev = num; // Store the first day's time
Days++;

while (num != 0)
{
    Console.WriteLine("Enter the seconds for day: " + Days);
    num = int.Parse(Console.ReadLine());

    if (num == 0) break; // Stop when the user inputs 0

    if (num > prev)
    {
        int Sum = num - prev; // Calculate difference
        Bad_Sum += Sum; // Add to bad sum

        if (Sum > Max) // Check for maximum improvement
        {
            Max = Sum;
            Max_Day = Days;
        }
    }
    else if (prev > num)
    {
        int Sum = prev - num; // Calculate difference
        Good_Sum += Sum; // Add to good sum
    }

    prev = num; // Update previous day
    Days++;
}

// Check if the bad sum is greater by at least 5
if (Bad_Sum - Good_Sum > 5)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}

// Output the day with the maximum improvement
Console.WriteLine("The best improvement was on day: " + Max_Day);