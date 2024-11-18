using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Domain.Entities;

class Program
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.Preserve,
        WriteIndented = true
    };

    private static readonly Dictionary<int, (string Name, List<object> Entities)> ComponentCategories = new Dictionary<int, (string, List<object>)>();
    private static readonly List<object> YourSetup = new List<object>();

    static void Main()
    {
        InitializeComponentCategories();

        bool continueProgram = true;
        while (continueProgram)
        {
            DisplayMenu();
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                ProcessChoice(choice, ref continueProgram);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            if (continueProgram && choice != 7)
            {
                Console.WriteLine("\nPress Enter key to return to the main menu...");
                Console.ReadKey();
            }
        }
    }

    private static void InitializeComponentCategories()
    {
        ComponentCategories.Add(1, ("Motherboards", LoadFromJson<MotherboardEntity>("JSONData/DataMotherboardEntities.json")));
        ComponentCategories.Add(2, ("Graphics Cards", LoadFromJson<GraphicsCardEntity>("JSONData/DataGraphicsCardEntities.json")));
        ComponentCategories.Add(3, ("Processors", LoadFromJson<ProcessorEntity>("JSONData/DataProcessorEntities.json")));
        ComponentCategories.Add(4, ("RAM", LoadFromJson<RamEntity>("JSONData/DataRamEntities.json")));
        ComponentCategories.Add(5, ("Disks", LoadFromJson<DiskEntity>("JSONData/DataDiskEntities.json")));
        ComponentCategories.Add(6, ("Power Supplies", LoadFromJson<PowerSupplyEntity>("JSONData/DataPowerSupplies.json")));
    }

    private static List<T> LoadFromJson<T>(string filename) =>
        JsonSerializer.Deserialize<List<T>>(File.ReadAllText(filename), Options);

    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Choose a category to display:");
        foreach (var category in ComponentCategories)
        {
            Console.WriteLine($"{category.Key}. {category.Value.Name}");
        }
        Console.WriteLine("7. Your chosen setup");
        Console.WriteLine("0. Exit");
        Console.Write("\nEnter your choice: ");
    }

    private static void ProcessChoice(int choice, ref bool continueProgram)
    {
        if (choice == 0)
        {
            continueProgram = false;
            Console.WriteLine("Exiting the program. Goodbye!");
        }
        else if (choice == 7)
        {
            DisplaySetup();
        }
        else if (ComponentCategories.TryGetValue(choice, out var category))
        {
            DisplayComponentsAndAddToSetup(category.Name, category.Entities);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }

    private static void DisplayComponentsAndAddToSetup(string categoryName, List<object> components)
    {
        Console.WriteLine($"\nAvailable {categoryName}:");
        for (int i = 0; i < components.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {components[i]}");
        }

        Console.Write($"\nEnter the number of the {categoryName.TrimEnd('s')} you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int componentChoice) && componentChoice > 0 && componentChoice <= components.Count)
        {
            YourSetup.Add(components[componentChoice - 1]);
            Console.WriteLine($"{categoryName.TrimEnd('s')} added to your setup.");
        }
        else if (componentChoice != 0)
        {
            Console.WriteLine($"Invalid choice. No {categoryName.TrimEnd('s')} added.");
        }
    }

    private static void DisplaySetup()
    {
        Console.WriteLine("\nYour current setup:");
        if (YourSetup.Count == 0)
        {
            Console.WriteLine("Your setup is empty.");
        }
        else
        {
            decimal totalCost = 0;
            foreach (var item in YourSetup)
            {
                Console.WriteLine(item);
                if (item is IEntity entity)
                {
                    totalCost += entity.ItemCost;
                }
            }
            Console.WriteLine($"\nTotal cost of your setup: {totalCost:C}");
        }
    }
}

public interface IEntity
{
    decimal ItemCost { get; set; }
}

// Ensure all your entity classes implement IEntity