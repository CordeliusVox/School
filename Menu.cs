using System;
using System.Collections.Generic;
using System.Threading;

class ArielRestaurantMenu
{
    static readonly MenuSettings Settings = new MenuSettings();

    static void Main()
    {
        Console.Title = Settings.RestaurantName;
        ShowWelcomeMessage();
        RunMenu();
    }

    static void ShowWelcomeMessage()
    {
        PrintDivider();
        PrintColoredText($"WELCOME TO {Settings.RestaurantName.ToUpper()}!", Settings.TitleColor);
        PrintDivider();
        Thread.Sleep(Settings.Delay);
        PrintColoredText("Enjoy the finest selection of dishes from around the world.", Settings.DefaultColor);
        Thread.Sleep(Settings.Delay);
        PrintColoredText("You can place orders, calculate totals, and much more!", Settings.DefaultColor);
        Thread.Sleep(Settings.Delay);
    }

    static void RunMenu()
    {
        var menu = Settings.FoodMenu;
        var order = new List<OrderItem>();

        while (true)
        {
            Console.Clear();
            PrintColoredText("========= FOOD MENU =========", Settings.TitleColor);

            var categories = new List<string>(menu.Keys);

            DisplayCategories(menu);

            PrintColoredText("\nSelect a category by number, type 'checkout' to finish, or 'exit' to leave:", Settings.DefaultColor);
            string input = Console.ReadLine()?.ToLower();

            if (input == "checkout")
            {
                ProcessCheckout(order);
                break;
            }
            else if (input == "exit")
            {
                PrintColoredText("\nThank you for visiting! Have a great day!", Settings.SuccessColor);
                Thread.Sleep(Settings.Delay);
                break;
            }

            if (int.TryParse(input, out int categoryIndex) && IsValidIndex(categoryIndex, categories.Count))
            {
                string category = categories[categoryIndex - 1];
                PlaceOrder(menu[category], order);
            }
            else
            {
                PrintColoredText("Invalid selection. Please try again.", Settings.ErrorColor);
                Thread.Sleep(Settings.Delay);
            }
        }
    }

    static void DisplayCategories(Dictionary<string, List<FoodItem>> menu)
    {
        int index = 1;
        foreach (var category in menu.Keys)
        {
            PrintColoredText($"{index}. {category}", Settings.CategoryColor);
            index++;
        }
    }

    static void PlaceOrder(List<FoodItem> items, List<OrderItem> order)
    {
        while (true)
        {
            Console.Clear();
            PrintDivider();
            PrintColoredText("Select Items", Settings.TitleColor);
            PrintDivider();

            for (int i = 0; i < items.Count; i++)
            {
                PrintColoredText($"{i + 1}. {items[i].Name} - ${items[i].Price:F2}", Settings.DefaultColor);
            }

            PrintColoredText("\nChoose an item by number, or type 'back' to return:", Settings.DefaultColor);
            string input = Console.ReadLine()?.ToLower();

            if (input == "back") break;

            if (int.TryParse(input, out int itemIndex) && IsValidIndex(itemIndex, items.Count))
            {
                var selectedItem = items[itemIndex - 1];
                PrintColoredText($"How many {selectedItem.Name} would you like to order?", Settings.DefaultColor);
                string quantityInput = Console.ReadLine();

                if (int.TryParse(quantityInput, out int quantity) && quantity > 0)
                {
                    order.Add(new OrderItem(selectedItem.Name, quantity, selectedItem.Price));
                    PrintColoredText($"{quantity} x {selectedItem.Name} added to your order!", Settings.SuccessColor);
                    Thread.Sleep(Settings.Delay);
                }
                else
                {
                    PrintColoredText("Invalid quantity. Returning to the menu.", Settings.ErrorColor);
                    Thread.Sleep(Settings.Delay);
                }
            }
            else
            {
                PrintColoredText("Invalid selection. Please try again.", Settings.ErrorColor);
                Thread.Sleep(Settings.Delay);
            }
        }
    }

    static void ProcessCheckout(List<OrderItem> order)
    {
        Console.Clear();
        PrintDivider();
        PrintColoredText("ORDER SUMMARY", Settings.TitleColor);
        PrintDivider();

        if (order.Count == 0)
        {
            PrintColoredText("No items in your order.", Settings.ErrorColor);
            Thread.Sleep(Settings.Delay);
            return;
        }

        double subtotal = 0;
        foreach (var item in order)
        {
            double itemTotal = item.Quantity * item.Price;
            subtotal += itemTotal;
            PrintColoredText($"{item.Quantity} x {item.Name} - ${item.Price:F2} each (Total: ${itemTotal:F2})", Settings.DefaultColor);
        }

        double tax = subtotal * Settings.TaxRate;
        double total = subtotal + tax;

        PrintColoredText($"\nSubtotal: ${subtotal:F2}", Settings.DefaultColor);
        PrintColoredText($"Tax ({Settings.TaxRate * 100}%): ${tax:F2}", Settings.DefaultColor);
        PrintColoredText($"Grand Total: ${total:F2}", Settings.SuccessColor);

        PrintColoredText("\nEnter payment amount:", Settings.DefaultColor);
        string paymentInput = Console.ReadLine();

        if (double.TryParse(paymentInput, out double payment) && payment >= total)
        {
            double change = payment - total;
            PrintColoredText($"Payment successful! Your change: ${change:F2}", Settings.SuccessColor);
            PrintColoredText("Thank you for your order! Have a great day!", Settings.SuccessColor);
        }
        else
        {
            PrintColoredText("Payment failed. Insufficient funds or invalid input. Dont try to scam me >:(", Settings.ErrorColor);
        }

        Thread.Sleep(Settings.Delay);
    }

    static bool IsValidIndex(int index, int count) => index > 0 && index <= count;

    static void PrintColoredText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    static void PrintDivider()
    {
        Console.WriteLine(new string('=', 40));
    }
}

class MenuSettings // The menu settings, Please do not change, if you do, return it back to what it was after u finish. Thank you :D
{
    public string RestaurantName { get; } = "Ariel's Restaurant"; // Main name of the Restaurant.
    public ConsoleColor TitleColor { get; } = ConsoleColor.Cyan; // Pretty self explantory, the color of the title.
    public ConsoleColor DefaultColor { get; } = ConsoleColor.White;
    public ConsoleColor CategoryColor { get; } = ConsoleColor.Yellow;
    public ConsoleColor SuccessColor { get; } = ConsoleColor.Green;
    public ConsoleColor ErrorColor { get; } = ConsoleColor.Red;
    public int Delay { get; } = 1000; // Delay between actions. Default is 1000 (1s)
    public double TaxRate { get; } = 0.07; // Tax rate. Default is 0.07 (7%)

    public Dictionary<string, List<FoodItem>> FoodMenu { get; } = new Dictionary<string, List<FoodItem>>()
    {
        { "Appetizers", new List<FoodItem> {
            new FoodItem("Garlic Bread", 5.99), // new FoodItem("FOOD NAME", FOOD PRICE),
            new FoodItem("Bruschetta", 6.99),
            new FoodItem("Spring Rolls", 7.99)
        }},
        { "Main Courses", new List<FoodItem> {
            new FoodItem("Grilled Salmon", 15.99),
            new FoodItem("Chicken Alfredo", 14.99),
            new FoodItem("Vegetarian Lasagna", 13.99)
        }},
        { "Desserts", new List<FoodItem> {
            new FoodItem("Cheesecake", 6.99),
            new FoodItem("Chocolate Lava Cake", 7.99),
            new FoodItem("Tiramisu", 8.99)
        }},
        { "Beverages", new List<FoodItem> {
            new FoodItem("Iced Tea", 2.99),
            new FoodItem("Cappuccino", 3.99),
            new FoodItem("Fresh Lemonade", 2.49)
        }}
    };
}

class FoodItem
{
    public string Name { get; }
    public double Price { get; }

    public FoodItem(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class OrderItem
{
    public string Name { get; }
    public int Quantity { get; }
    public double Price { get; }

    public OrderItem(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
    // nice coding! we enjoyed our test run. in the end with "Insufficient funds" try making it in a while, because we stole your food without paying :-}
    // ^ Thank you for the feedback! I will keep it in mind. ^
