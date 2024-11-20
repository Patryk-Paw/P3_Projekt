using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using Domain.Entities;

// Basic options for serialization
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    ReferenceHandler = ReferenceHandler.Preserve,
    WriteIndented = true
};

// Loading all objects from .JSON file
List<PowerSupplyEntity> powerSupplies = JsonSerializer.Deserialize<List<PowerSupplyEntity>>(File.ReadAllText("../../../../JSONData/DataPowerSupplies.json"), options);
List<DiskEntity> diskEntities = JsonSerializer.Deserialize<List<DiskEntity>>(File.ReadAllText("../../../../JSONData/DataDiskEntities.json"), options);
List<MotherboardEntity> motherboardEntities = JsonSerializer.Deserialize<List<MotherboardEntity>>(File.ReadAllText("../../../../JSONData/DataMotherboardEntities.json"), options);
List<RamEntity> ramEntities = JsonSerializer.Deserialize<List<RamEntity>>(File.ReadAllText("../../../../JSONData/DataRamEntities.json"), options);
List<GraphicsCardEntity> graphicsCardEntities = JsonSerializer.Deserialize<List<GraphicsCardEntity>>(File.ReadAllText("../../../../JSONData/DataGraphicsCardEntities.json"), options);
List<ProcessorEntity> processorEntities = JsonSerializer.Deserialize<List<ProcessorEntity>>(File.ReadAllText("../../../../JSONData/DataProcessorEntities.json"), options);

List<object> yourSetup = new List<object>();
// Menu
bool continueProgram = true;
while (continueProgram)
{
    Console.Clear();
    Console.WriteLine("Choose a category to display:");
    Console.WriteLine("1. Motherboards");
    Console.WriteLine("2. Graphics Cards");
    Console.WriteLine("3. Processors");
    Console.WriteLine("4. RAM");
    Console.WriteLine("5. Disks");
    Console.WriteLine("6. Power Supplies");
    Console.WriteLine("7. Your chosen setup");
    Console.WriteLine("0. Exit");

    Console.Write("\nEnter your choice: ");
    int number = Convert.ToInt32(Console.ReadLine());
    int choice;
    switch (number)
    {
        case 0:
            continueProgram = false;
            Console.WriteLine("Exiting the program. Goodbye!");
            break;

        case 1:
            Console.WriteLine("\nAvailable Motherboards:");
            for (int i = 0; i < motherboardEntities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Motherboard: {motherboardEntities[i].MotherboardName}, Chipset: {motherboardEntities[i].MotherboardChipset}, " +
                    $"RAM Type: {motherboardEntities[i].RamType}, Max RAM: {motherboardEntities[i].MaxRamCapacity}GB, Price: {motherboardEntities[i].ItemCost}");
            }

            Console.Write("\nEnter the number of the motherboard you want to add to your setup (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= motherboardEntities.Count)
            {
                yourSetup.Add(motherboardEntities[choice - 1]);
                Console.WriteLine("Motherboard added to your setup.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice. No motherboard added.");
            }
            break;

        case 2:
            Console.WriteLine("\nAvailable Graphics Cards:");
            for (int i = 0; i < graphicsCardEntities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. GPU: {graphicsCardEntities[i].GraphicsName}, VRAM: {graphicsCardEntities[i].GraphicsRam}GB, " +
                    $"Core Frequency: {graphicsCardEntities[i].GraphicsCoreFrequency}MHz, Power: {graphicsCardEntities[i].RecommendedGraphicsPower}W, " +
                    $"Price: {graphicsCardEntities[i].ItemCost}");
            }

            Console.Write("\nEnter the number of the graphics card you want to add to your setup (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= graphicsCardEntities.Count)
            {
                yourSetup.Add(graphicsCardEntities[choice - 1]);
                Console.WriteLine("Graphics card added to your setup.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice. No graphics card added.");
            }
            break;

        case 3:
            Console.WriteLine("\nAvailable Processors:");
            for (int i = 0; i < processorEntities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Processor: {processorEntities[i].ProcessorName}, Cores: {processorEntities[i].ProcessorCores}, " +
                    $"Threads: {processorEntities[i].ProcessorThreads}, Frequency: {processorEntities[i].ProcessorFrequency}GHz, " +
                    $"Price: {processorEntities[i].ItemCost}");
            }

            Console.Write("\nEnter the number of the processor you want to add to your setup (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= processorEntities.Count)
            {
                yourSetup.Add(processorEntities[choice - 1]);
                Console.WriteLine("Processor added to your setup.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice. No processor added.");
            }
            break;

        case 4:
            Console.WriteLine("\nAvailable RAM:");
            for (int i = 0; i < ramEntities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. RAM: {ramEntities[i].RamName}, Capacity: {ramEntities[i].RamCapacity}GB, " +
                    $"Frequency: {ramEntities[i].RamFrequency}MHz, Modules: {ramEntities[i].ModulesNumber}, " +
                    $"Price: {ramEntities[i].ItemCost}");
            }

            Console.Write("\nEnter the number of the RAM you want to add to your setup (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= ramEntities.Count)
            {
                yourSetup.Add(ramEntities[choice - 1]);
                Console.WriteLine("RAM added to your setup.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice. No RAM added.");
            }
            break;

        case 5:
            Console.WriteLine("\nAvailable Disks:");
            for (int i = 0; i < diskEntities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Disk: {diskEntities[i].DiskName}, Capacity: {diskEntities[i].DiskCapacity}GB, " +
                    $"Read Speed: {diskEntities[i].DiskReading}MB/s, Write Speed: {diskEntities[i].DiskWrite}MB/s, " +
                    $"Price: {diskEntities[i].ItemCost}");
            }

            Console.Write("\nEnter the number of the disk you want to add to your setup (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= diskEntities.Count)
            {
                yourSetup.Add(diskEntities[choice - 1]);
                Console.WriteLine("Disk added to your setup.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice. No disk added.");
            }
            break;

        case 6:
            Console.WriteLine("\nAvailable Power Supplies:");
            for (int i = 0; i < powerSupplies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Power Supply: {powerSupplies[i].PowerName}, Wattage: {powerSupplies[i].PowerValue}, " +
                    $"Price: {powerSupplies[i].ItemCost}");
            }

            Console.Write("\nEnter the number of the power supply you want to add to your setup (0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= powerSupplies.Count)
            {
                yourSetup.Add(powerSupplies[choice - 1]);
                Console.WriteLine("Power supply added to your setup.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice. No power supply added.");
            }
            break;

        case 7:
            Console.WriteLine("\nYour current setup:");
            if (yourSetup.Count == 0)
            {
                Console.WriteLine("Your setup is empty.");
            }
            else
            {
                double? totalCost = 0;
                foreach (var item in yourSetup)
                {
                    if (item is MotherboardEntity motherboard)
                    {
                        Console.WriteLine($"Motherboard: {motherboard.MotherboardName}, Chipset: {motherboard.MotherboardChipset}, " +
                            $"RAM Type: {motherboard.RamType}, Max RAM: {motherboard.MaxRamCapacity}GB, Price: {motherboard.ItemCost:C}");
                        totalCost += motherboard.ItemCost;
                    }
                    else if (item is GraphicsCardEntity gpu)
                    {
                        Console.WriteLine($"GPU: {gpu.GraphicsName}, VRAM: {gpu.GraphicsRam}GB, Core Frequency: {gpu.GraphicsCoreFrequency}MHz, " +
                            $"Power: {gpu.RecommendedGraphicsPower}W, Price: {gpu.ItemCost:C}");
                        totalCost += gpu.ItemCost;
                    }
                    else if (item is ProcessorEntity processor)
                    {
                        Console.WriteLine($"Processor: {processor.ProcessorName}, Cores: {processor.ProcessorCores}, Threads: {processor.ProcessorThreads}, " +
                            $"Frequency: {processor.ProcessorFrequency}GHz, Price: {processor.ItemCost:C}");
                        totalCost += processor.ItemCost;
                    }
                    else if (item is RamEntity ram)
                    {
                        Console.WriteLine($"RAM: {ram.RamName}, Capacity: {ram.RamCapacity}GB, Frequency: {ram.RamFrequency}MHz, " +
                            $"Modules: {ram.ModulesNumber}, Price: {ram.ItemCost:C}");
                        totalCost += ram.ItemCost;
                    }
                    else if (item is DiskEntity disk)
                    {
                        Console.WriteLine($"Disk: {disk.DiskName}, Capacity: {disk.DiskCapacity}GB, Read Speed: {disk.DiskReading}MB/s, " +
                            $"Write Speed: {disk.DiskWrite}MB/s, Price: {disk.ItemCost:C}");
                        totalCost += disk.ItemCost;
                    }
                    else if (item is PowerSupplyEntity powerSupply)
                    {
                        Console.WriteLine($"Power Supply: {powerSupply.PowerName}, Wattage: {powerSupply.PowerValue}, Price: {powerSupply.ItemCost:C}");
                        totalCost += powerSupply.ItemCost;
                    }
                }
                Console.WriteLine($"\nTotal cost of your setup: {totalCost:C}");
            }
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
    if (continueProgram)
    {
        Console.WriteLine("\nPress Enter key to return to the main menu...");
        Console.ReadKey();
    }
}
