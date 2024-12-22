using System;
using System.Collections.Generic;
using System.Threading;

class FoodMenu
{
    static void Main()
    {
        Console.Title = "Welcome to Gourmet Delight!";
        ShowWelcomeMessage();
        ShowMenu();
    }

    static void ShowWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("==========================================");
        Console.WriteLine("        WELCOME TO GOURMET DELIGHT        ");
        Console.WriteLine("==========================================");
        Console.ResetColor();
        Thread.Sleep(1000);
        Console.WriteLine("Enjoy the finest selection of dishes from around the world.");
        Thread.Sleep(1000);
        Console.WriteLine("Let's explore the menu!\n");
        Thread.Sleep(1000);
    }

    static void ShowMenu()
    {
        Dictionary<string, List<string>> menu = new Dictionary<string, List<string>>()
        {
            {
                "Appetizers",
                new List<string>() { "Garlic Bread - $5.99", "Bruschetta - $6.99", "Spring Rolls - $7.99" }
            },
            {
                "Main Courses",
                new List<string>() { "Grilled Salmon - $15.99", "Chicken Alfredo - $14.99", "Vegetarian Lasagna - $13.99" }
            },
            {
                "Desserts",
                new List<string>() { "Cheesecake - $6.99", "Chocolate Lava Cake - $7.99", "Tiramisu - $8.99" }
            },
            {
                "Beverages",
                new List<string>() { "Iced Tea - $2.99", "Cappuccino - $3.99", "Fresh Lemonade - $2.49" }
            }
        };

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("========= GOURMET MENU =========");
            Console.ResetColor();

            int categoryNumber = 1;
            foreach (var category in menu.Keys)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{categoryNumber}. {category}");
                Console.ResetColor();
                categoryNumber++;
            }

            Console.WriteLine("\nPlease select a category by number, or type 'exit' to leave:");

            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                Console.WriteLine("\nThank you for visiting Gourmet Delight. Have a wonderful day!");
                Thread.Sleep(1500);
                break;
            }

            if (int.TryParse(input, out int selectedCategory) && selectedCategory > 0 && selectedCategory <= menu.Keys.Count)
            {
                string category = GetCategoryByIndex(menu, selectedCategory - 1);
                DisplayCategoryItems(menu, category);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid selection. Please try again.");
                Console.ResetColor();
                Thread.Sleep(1500);
            }
        }
    }

    static string GetCategoryByIndex(Dictionary<string, List<string>> menu, int index)
    {
        int currentIndex = 0;
        foreach (var category in menu.Keys)
        {
            if (currentIndex == index)
            {
                return category;
            }
            currentIndex++;
        }
        return null;
    }

    static void DisplayCategoryItems(Dictionary<string, List<string>> menu, string category)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"==== {category.ToUpper()} ====");
        Console.ResetColor();

        List<string> items = menu[category];
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine("\nPress Enter to go back to the main menu.");
        Console.ReadLine();
    }
}