using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Domain.Entities;

public class Menu
{
    private List<PowerSupplyEntity> powerSupplies;
    private List<DiskEntity> diskEntities;
    private List<MotherboardEntity> motherboardEntities;
    private List<RamEntity> ramEntities;
    private List<GraphicsCardEntity> graphicsCardEntities;
    private List<ProcessorEntity> processorEntities;
    private List<object> yourSetup;
    private MotherboardEntity selectedMotherboard;
    private double? totalRamCapacity;
    private Add addComponent;
    private Display display;

    public Menu()
    {
        yourSetup = new List<object>();
        selectedMotherboard = null;
        totalRamCapacity = 0;
        addComponent = new Add();
        display = new Display();
    }

    public void Run()
    {
        LoadData();
        RunMenu();
    }

    private void LoadData()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true
        };

        powerSupplies = JsonSerializer.Deserialize<List<PowerSupplyEntity>>(File.ReadAllText("../../../../JSONData/DataPowerSupplies.json"), options);
        diskEntities = JsonSerializer.Deserialize<List<DiskEntity>>(File.ReadAllText("../../../../JSONData/DataDiskEntities.json"), options);
        motherboardEntities = JsonSerializer.Deserialize<List<MotherboardEntity>>(File.ReadAllText("../../../../JSONData/DataMotherboardEntities.json"), options);
        ramEntities = JsonSerializer.Deserialize<List<RamEntity>>(File.ReadAllText("../../../../JSONData/DataRamEntities.json"), options);
        graphicsCardEntities = JsonSerializer.Deserialize<List<GraphicsCardEntity>>(File.ReadAllText("../../../../JSONData/DataGraphicsCardEntities.json"), options);
        processorEntities = JsonSerializer.Deserialize<List<ProcessorEntity>>(File.ReadAllText("../../../../JSONData/DataProcessorEntities.json"), options);
    }
    private void RunMenu()
    {
        bool continueProgram = true;
        while (continueProgram)
        {
            Console.Clear();
            Console.WriteLine("Choose a category to display:");
            Console.WriteLine("1. Motherboards");
            Console.WriteLine("2. Processors");
            Console.WriteLine("3. RAM");
            Console.WriteLine("4. Disks");
            Console.WriteLine("5. Graphics Cards");
            Console.WriteLine("6. Power Supplies");
            Console.WriteLine("7. Your chosen setup");
            Console.WriteLine("8. Add new part");
            Console.WriteLine("0. Exit");

            Console.Write("\nEnter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 0:
                        continueProgram = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    case 1:
                        display.Motherboards(motherboardEntities, ref selectedMotherboard, yourSetup, ref totalRamCapacity);
                        break;
                    case 2:
                        display.Processors(processorEntities, selectedMotherboard, yourSetup);
                        break;
                    case 3:
                        display.RAM(ramEntities, selectedMotherboard, yourSetup, ref totalRamCapacity);
                        break;
                    case 4:
                        display.Disks(diskEntities, selectedMotherboard, yourSetup);
                        break;
                    case 5:
                        display.GraphicsCards(graphicsCardEntities, selectedMotherboard, yourSetup);
                        break;
                    case 6:
                        display.PowerSupplies(powerSupplies, yourSetup);
                        break;
                    case 7:
                        display.YourSetup(yourSetup, totalRamCapacity);
                        break;
                    case 8:
                        AddNewPart();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            if (continueProgram)
            {
                Console.WriteLine("\nPress Enter key to return to the main menu...");
                Console.ReadKey();
            }
        }
    }

    private void AddNewPart()
    {
        Console.WriteLine("Select the type of part you want to add:");
        Console.WriteLine("1. Motherboard");
        Console.WriteLine("2. Processor");
        Console.WriteLine("3. RAM");
        Console.WriteLine("4. Disk");
        Console.WriteLine("5. Graphics Card");
        Console.WriteLine("6. Power Supply");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    addComponent.Motherboard(motherboardEntities);
                    break;
                case 2:
                    addComponent.Processor(processorEntities);
                    break;
                case 3:
                    addComponent.RAM(ramEntities);
                    break;
                case 4:
                    addComponent.Disk(diskEntities);
                    break;
                case 5:
                    addComponent.GraphicsCard(graphicsCardEntities);
                    break;
                case 6:
                    addComponent.PowerSupply(powerSupplies);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}