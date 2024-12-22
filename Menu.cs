using System;
using System.Collections.Generic;
using System.Threading;

class AdvancedFoodMenu
{
    static void Main()
    {
        Console.Title = "Gourmet Delight - Advanced Food Menu";
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
        Console.WriteLine("You can place orders, calculate totals, and much more!\n");
        Thread.Sleep(1500);
    }

    static void ShowMenu()
    {
        Dictionary<string, List<(string Name, double Price)>> menu = new Dictionary<string, List<(string Name, double Price)>>()
        {
            { "Appetizers", new List<(string, double)>() {
                ("Garlic Bread", 5.99), ("Bruschetta", 6.99), ("Spring Rolls", 7.99)
            }},
            { "Main Courses", new List<(string, double)>() {
                ("Grilled Salmon", 15.99), ("Chicken Alfredo", 14.99), ("Vegetarian Lasagna", 13.99)
            }},
            { "Desserts", new List<(string, double)>() {
                ("Cheesecake", 6.99), ("Chocolate Lava Cake", 7.99), ("Tiramisu", 8.99)
            }},
            { "Beverages", new List<(string, double)>() {
                ("Iced Tea", 2.99), ("Cappuccino", 3.99), ("Fresh Lemonade", 2.49)
            }}
        };

        List<(string Name, int Quantity, double Price)> order = new List<(string, int, double)>();

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

            Console.WriteLine("\nPlease select a category by number, or type 'checkout' to finish your order:");

            string input = Console.ReadLine();
            if (input.ToLower() == "checkout")
            {
                ShowOrderSummary(order);
                break;
            }

            if (int.TryParse(input, out int selectedCategory) && selectedCategory > 0 && selectedCategory <= menu.Keys.Count)
            {
                string category = GetCategoryByIndex(menu, selectedCategory - 1);
                PlaceOrder(menu, category, order);
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

    static string GetCategoryByIndex(Dictionary<string, List<(string Name, double Price)>> menu, int index)
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

    static void PlaceOrder(Dictionary<string, List<(string Name, double Price)>> menu, string category, List<(string Name, int Quantity, double Price)> order)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"==== {category.ToUpper()} ====");
        Console.ResetColor();

        List<(string Name, double Price)> items = menu[category];
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} - ${items[i].Price:F2}");
        }

        Console.WriteLine("\nSelect an item by number, or type 'back' to return to the main menu:");
        string input = Console.ReadLine();

        if (input.ToLower() == "back")
        {
            return;
        }

        if (int.TryParse(input, out int selectedItem) && selectedItem > 0 && selectedItem <= items.Count)
        {
            var selectedItemData = items[selectedItem - 1];
            Console.WriteLine($"\nHow many {selectedItemData.Name} would you like to order?");
            string quantityInput = Console.ReadLine();

            if (int.TryParse(quantityInput, out int quantity) && quantity > 0)
            {
                order.Add((selectedItemData.Name, quantity, selectedItemData.Price));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{quantity} x {selectedItemData.Name} added to your order!");
                Console.ResetColor();
                Thread.Sleep(1500);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid quantity. Returning to the menu.");
                Console.ResetColor();
                Thread.Sleep(1500);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid selection. Returning to the menu.");
            Console.ResetColor();
            Thread.Sleep(1500);
        }
    }

    static void ShowOrderSummary(List<(string Name, int Quantity, double Price)> order)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("========== ORDER SUMMARY ==========");
        Console.ResetColor();

        if (order.Count == 0)
        {
            Console.WriteLine("You have no items in your order.");
            Console.WriteLine("Thank you for visiting Gourmet Delight!");
            Thread.Sleep(2000);
            return;
        }

        double total = 0;
        foreach (var item in order)
        {
            double itemTotal = item.Quantity * item.Price;
            total += itemTotal;
            Console.WriteLine($"{item.Quantity} x {item.Name} - ${item.Price:F2} each (Total: ${itemTotal:F2})");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nGrand Total: ${total:F2}");
        Console.ResetColor();

        Console.WriteLine("\nEnter payment amount:");
        string paymentInput = Console.ReadLine();

        if (double.TryParse(paymentInput, out double payment) && payment >= total)
        {
            double change = payment - total;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nPayment successful! Your change is: ${change:F2}");
            Console.WriteLine("Thank you for your order! Have a great day!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPayment failed. Insufficient funds or invalid input.");
            Console.ResetColor();
        }

        Thread.Sleep(3000);
    }
}