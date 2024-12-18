using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using Domain.Entities;

class Program
{
    static List<PowerSupplyEntity> powerSupplies;
    static List<DiskEntity> diskEntities;
    static List<MotherboardEntity> motherboardEntities;
    static List<RamEntity> ramEntities;
    static List<GraphicsCardEntity> graphicsCardEntities;
    static List<ProcessorEntity> processorEntities;
    static List<object> yourSetup = new List<object>();
    static MotherboardEntity selectedMotherboard = null;
    static double? totalRamCapacity = 0;

    static void Main(string[] args)
    {
        LoadData();
        RunMenu();
    }

    static void LoadData()
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

    static void RunMenu()
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
                        DisplayMotherboards();
                        break;
                    case 2:
                        DisplayProcessors();
                        break;
                    case 3:
                        DisplayRAM();
                        break;
                    case 4:
                        DisplayDisks();
                        break;
                    case 5:
                        DisplayGraphicsCards();
                        break;
                    case 6:
                        DisplayPowerSupplies();
                        break;
                    case 7:
                        DisplayYourSetup();
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

    static void DisplayMotherboards()
    {
        Console.WriteLine("\nAvailable Motherboards:");
        for (int i = 0; i < motherboardEntities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Motherboard: {motherboardEntities[i].MotherboardName}, Chipset: {motherboardEntities[i].MotherboardChipset}, " +
                $"RAM Type: {motherboardEntities[i].RamType}, Max RAM: {motherboardEntities[i].MaxRamCapacity}GB, Price: {motherboardEntities[i].ItemCost}");
        }

        Console.Write("\nEnter the number of the motherboard you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= motherboardEntities.Count)
        {
            selectedMotherboard = motherboardEntities[choice - 1];
            yourSetup.Clear(); // Clear previous setup
            yourSetup.Add(selectedMotherboard);
            totalRamCapacity = 0; // Reset total RAM capacity
            Console.WriteLine("Motherboard added to your setup. Other components will be filtered based on this selection.");
        }
        else if (choice != 0)
        {
            Console.WriteLine("Invalid choice. No motherboard added.");
        }
    }

    static void DisplayProcessors()
    {
        if (selectedMotherboard == null)
        {
            Console.WriteLine("Please select a motherboard first.");
            return;
        }

        var compatibleProcessors = processorEntities.Where(p => selectedMotherboard.ProcessorSockets.Contains(p.ProcessorSocket)).ToList();

        Console.WriteLine("\nCompatible Processors:");
        for (int i = 0; i < compatibleProcessors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Processor: {compatibleProcessors[i].ProcessorName}, Cores: {compatibleProcessors[i].ProcessorCores}, " +
                $"Threads: {compatibleProcessors[i].ProcessorThreads}, Frequency: {compatibleProcessors[i].ProcessorFrequency}GHz, " +
                $"Price: {compatibleProcessors[i].ItemCost}");
        }

        Console.Write("\nEnter the number of the processor you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleProcessors.Count)
        {
            yourSetup.Add(compatibleProcessors[choice - 1]);
            Console.WriteLine("Processor added to your setup.");
        }
        else if (choice != 0)
        {
            Console.WriteLine("Invalid choice. No processor added.");
        }
    }

    static void DisplayRAM()
    {
        if (selectedMotherboard == null)
        {
            Console.WriteLine("Please select a motherboard first.");
            return;
        }

        double? remainingRamCapacity = selectedMotherboard.MaxRamCapacity - totalRamCapacity;

        if (remainingRamCapacity <= 0)
        {
            Console.WriteLine($"You've already reached the maximum RAM capacity for this motherboard ({selectedMotherboard.MaxRamCapacity}GB).");
            return;
        }

        var compatibleRAM = ramEntities.Where(r =>
            r.RamType == selectedMotherboard.RamType &&
            r.RamSocket == selectedMotherboard.RamSockets.FirstOrDefault() &&
            r.RamCapacity <= remainingRamCapacity).ToList();

        Console.WriteLine($"\nCompatible RAM (Remaining capacity: {remainingRamCapacity}GB):");
        for (int i = 0; i < compatibleRAM.Count; i++)
        {
            Console.WriteLine($"{i + 1}. RAM: {compatibleRAM[i].RamName}, Capacity: {compatibleRAM[i].RamCapacity}GB, " +
                $"Frequency: {compatibleRAM[i].RamFrequency}MHz, Modules: {compatibleRAM[i].ModulesNumber}, " +
                $"Price: {compatibleRAM[i].ItemCost}");
        }

        Console.Write("\nEnter the number of the RAM you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleRAM.Count)
        {
            var selectedRam = compatibleRAM[choice - 1];
            yourSetup.Add(selectedRam);
            totalRamCapacity += selectedRam.RamCapacity;
            Console.WriteLine($"RAM added to your setup. Total RAM capacity: {totalRamCapacity}GB");
        }
        else if (choice != 0)
        {
            Console.WriteLine("Invalid choice. No RAM added.");
        }
    }

    static void DisplayDisks()
    {
        if (selectedMotherboard == null)
        {
            Console.WriteLine("Please select a motherboard first.");
            return;
        }

        var compatibleDisks = diskEntities.Where(d => selectedMotherboard.DiskSockets.Contains(d.DiskSocket)).ToList();

        Console.WriteLine("\nCompatible Disks:");
        for (int i = 0; i < compatibleDisks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Disk: {compatibleDisks[i].DiskName}, Capacity: {compatibleDisks[i].DiskCapacity}GB, " +
                $"Read Speed: {compatibleDisks[i].DiskReading}MB/s, Write Speed: {compatibleDisks[i].DiskWrite}MB/s, " +
                $"Price: {compatibleDisks[i].ItemCost}");
        }

        Console.Write("\nEnter the number of the disk you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleDisks.Count)
        {
            yourSetup.Add(compatibleDisks[choice - 1]);
            Console.WriteLine("Disk added to your setup.");
        }
        else if (choice != 0)
        {
            Console.WriteLine("Invalid choice. No disk added.");
        }
    }

    static void DisplayGraphicsCards()
    {
        if (selectedMotherboard == null)
        {
            Console.WriteLine("Please select a motherboard first.");
            return;
        }

        var compatibleGraphicsCards = graphicsCardEntities.Where(g => selectedMotherboard.GraphicsSockets.Contains(g.GraphicsSocket)).ToList();

        Console.WriteLine("\nCompatible Graphics Cards:");
        for (int i = 0; i < compatibleGraphicsCards.Count; i++)
        {
            Console.WriteLine($"{i + 1}. GPU: {compatibleGraphicsCards[i].GraphicsName}, VRAM: {compatibleGraphicsCards[i].GraphicsRam}GB, " +
                $"Core Frequency: {compatibleGraphicsCards[i].GraphicsCoreFrequency}MHz, Power: {compatibleGraphicsCards[i].RecommendedGraphicsPower}W, " +
                $"Price: {compatibleGraphicsCards[i].ItemCost}");
        }

        Console.Write("\nEnter the number of the graphics card you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleGraphicsCards.Count)
        {
            yourSetup.Add(compatibleGraphicsCards[choice - 1]);
            Console.WriteLine("Graphics card added to your setup.");
        }
        else if (choice != 0)
        {
            Console.WriteLine("Invalid choice. No graphics card added.");
        }
    }

    static void DisplayPowerSupplies()
    {
        Console.WriteLine("\nAvailable Power Supplies:");
        for (int i = 0; i < powerSupplies.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Power Supply: {powerSupplies[i].PowerName}, Wattage: {powerSupplies[i].PowerValue}, " +
                $"Price: {powerSupplies[i].ItemCost}");
        }

        Console.Write("\nEnter the number of the power supply you want to add to your setup (0 to cancel): ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= powerSupplies.Count)
        {
            yourSetup.Add(powerSupplies[choice - 1]);
            Console.WriteLine("Power supply added to your setup.");
        }
        else if (choice != 0)
        {
            Console.WriteLine("Invalid choice. No power supply added.");
        }
    }

    static void DisplayYourSetup()
    {
        Console.WriteLine("\nYour current setup:");
        if (yourSetup.Count == 0)
        {
            Console.WriteLine("Your setup is empty.");
        }
        else
        {
            double totalCost = 0;
            foreach (var item in yourSetup)
            {
                if (item is MotherboardEntity motherboard)
                {
                    Console.WriteLine($"Motherboard: {motherboard.MotherboardName}, Chipset: {motherboard.MotherboardChipset}, " +
                        $"RAM Type: {motherboard.RamType}, Max RAM: {motherboard.MaxRamCapacity}GB, Price: {motherboard.ItemCost:C}");
                    totalCost += motherboard.ItemCost ?? 0;
                }
                else if (item is GraphicsCardEntity gpu)
                {
                    Console.WriteLine($"GPU: {gpu.GraphicsName}, VRAM: {gpu.GraphicsRam}GB, Core Frequency: {gpu.GraphicsCoreFrequency}MHz, " +
                        $"Power: {gpu.RecommendedGraphicsPower}W, Price: {gpu.ItemCost:C}");
                    totalCost += gpu.ItemCost ?? 0;
                }
                else if (item is ProcessorEntity processor)
                {
                    Console.WriteLine($"Processor: {processor.ProcessorName}, Cores: {processor.ProcessorCores}, Threads: {processor.ProcessorThreads}, " +
                        $"Frequency: {processor.ProcessorFrequency}GHz, Price: {processor.ItemCost:C}");
                    totalCost += processor.ItemCost ?? 0;
                }
                else if (item is RamEntity ram)
                {
                    Console.WriteLine($"RAM: {ram.RamName}, Capacity: {ram.RamCapacity}GB, Frequency: {ram.RamFrequency}MHz, " +
                        $"Modules: {ram.ModulesNumber}, Price: {ram.ItemCost:C}");
                    totalCost += ram.ItemCost ?? 0;
                }
                else if (item is DiskEntity disk)
                {
                    Console.WriteLine($"Disk: {disk.DiskName}, Capacity: {disk.DiskCapacity}GB, Read Speed: {disk.DiskReading}MB/s, " +
                        $"Write Speed: {disk.DiskWrite}MB/s, Price: {disk.ItemCost:C}");
                    totalCost += disk.ItemCost ?? 0;
                }
                else if (item is PowerSupplyEntity powerSupply)
                {
                    Console.WriteLine($"Power Supply: {powerSupply.PowerName}, Wattage: {powerSupply.PowerValue}, Price: {powerSupply.ItemCost:C}");
                    totalCost += powerSupply.ItemCost ?? 0;
                }
            }
            Console.WriteLine($"\nTotal RAM capacity: {totalRamCapacity}GB");
            Console.WriteLine($"Total cost of your setup: {totalCost:C}");
        }
    }
}
