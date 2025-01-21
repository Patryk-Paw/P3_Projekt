using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

public class Display
{
    public void Motherboards(List<MotherboardEntity> motherboardEntities, ref MotherboardEntity selectedMotherboard, List<object> yourSetup, ref double? totalRamCapacity)
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

    public void Processors(List<ProcessorEntity> processorEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup)
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

    public void RAM(List<RamEntity> ramEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup, ref double? totalRamCapacity)
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

    public void Disks(List<DiskEntity> diskEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup)
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

    public void GraphicsCards(List<GraphicsCardEntity> graphicsCardEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup)
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

    public void PowerSupplies(List<PowerSupplyEntity> powerSupplies, List<object> yourSetup)
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

    public void YourSetup(List<object> yourSetup, double? totalRamCapacity)
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
// --------LINQ Version--------
//public void Motherboards(List<MotherboardEntity> motherboardEntities, ref MotherboardEntity selectedMotherboard, List<object> yourSetup, ref double? totalRamCapacity)
//{
//    Console.WriteLine("\nAvailable Motherboards:");

//    motherboardEntities.Select((mb, index) => new { Index = index + 1, Motherboard = mb })
//        .ToList()
//        .ForEach(item => Console.WriteLine($"{item.Index}. Motherboard: {item.Motherboard.MotherboardName}, " +
//            $"Chipset: {item.Motherboard.MotherboardChipset}, " +
//            $"RAM Type: {item.Motherboard.RamType}, " +
//            $"Max RAM: {item.Motherboard.MaxRamCapacity}GB, " +
//            $"Price: {item.Motherboard.ItemCost}"));

//    Console.Write("\nEnter the number of the motherboard you want to add to your setup (0 to cancel): ");
//    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= motherboardEntities.Count)
//    {
//        selectedMotherboard = motherboardEntities[choice - 1];
//        yourSetup.Clear(); // Clear previous setup
//        yourSetup.Add(selectedMotherboard);
//        totalRamCapacity = 0; // Reset total RAM capacity
//        Console.WriteLine("Motherboard added to your setup. Other components will be filtered based on this selection.");
//    }
//    else if (choice != 0)
//    {
//        Console.WriteLine("Invalid choice. No motherboard added.");
//    }
////}
//public void Processors(List<ProcessorEntity> processorEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup)
//{
//    if (selectedMotherboard == null)
//    {
//        Console.WriteLine("Please select a motherboard first.");
//        return;
//    }

//    var compatibleProcessors = processorEntities.Where(p => selectedMotherboard.ProcessorSockets.Contains(p.ProcessorSocket)).ToList();

//    Console.WriteLine("\nCompatible Processors:");
//    compatibleProcessors.Select((p, index) => new { Index = index + 1, Processor = p })
//        .ToList()
//        .ForEach(item => Console.WriteLine($"{item.Index}. Processor: {item.Processor.ProcessorName}, " +
//            $"Cores: {item.Processor.ProcessorCores}, " +
//            $"Threads: {item.Processor.ProcessorThreads}, " +
//            $"Frequency: {item.Processor.ProcessorFrequency}GHz, " +
//            $"Price: {item.Processor.ItemCost}"));

//    Console.Write("\nEnter the number of the processor you want to add to your setup (0 to cancel): ");
//    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleProcessors.Count)
//    {
//        yourSetup.Add(compatibleProcessors[choice - 1]);
//        Console.WriteLine("Processor added to your setup.");
//    }
//    else if (choice != 0)
//    {
//        Console.WriteLine("Invalid choice. No processor added.");
//    }
//}

//public void RAM(List<RamEntity> ramEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup, ref double? totalRamCapacity)
//{
//    if (selectedMotherboard == null)
//    {
//        Console.WriteLine("Please select a motherboard first.");
//        return;
//    }

//    double? remainingRamCapacity = selectedMotherboard.MaxRamCapacity - totalRamCapacity;

//    if (remainingRamCapacity <= 0)
//    {
//        Console.WriteLine($"You've already reached the maximum RAM capacity for this motherboard ({selectedMotherboard.MaxRamCapacity}GB).");
//        return;
//    }

//    var compatibleRAM = ramEntities.Where(r =>
//        r.RamType == selectedMotherboard.RamType &&
//        r.RamSocket == selectedMotherboard.RamSockets.FirstOrDefault() &&
//        r.RamCapacity <= remainingRamCapacity).ToList();

//    Console.WriteLine($"\nCompatible RAM (Remaining capacity: {remainingRamCapacity}GB):");
//    compatibleRAM.Select((r, index) => new { Index = index + 1, RAM = r })
//        .ToList()
//        .ForEach(item => Console.WriteLine($"{item.Index}. RAM: {item.RAM.RamName}, " +
//            $"Capacity: {item.RAM.RamCapacity}GB, " +
//            $"Frequency: {item.RAM.RamFrequency}MHz, " +
//            $"Modules: {item.RAM.ModulesNumber}, " +
//            $"Price: {item.RAM.ItemCost}"));

//    Console.Write("\nEnter the number of the RAM you want to add to your setup (0 to cancel): ");
//    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleRAM.Count)
//    {
//        var selectedRam = compatibleRAM[choice - 1];
//        yourSetup.Add(selectedRam);
//        totalRamCapacity += selectedRam.RamCapacity;
//        Console.WriteLine($"RAM added to your setup. Total RAM capacity: {totalRamCapacity}GB");
//    }
//    else if (choice != 0)
//    {
//        Console.WriteLine("Invalid choice. No RAM added.");
//    }
//}

//public void Disks(List<DiskEntity> diskEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup)
//{
//    if (selectedMotherboard == null)
//    {
//        Console.WriteLine("Please select a motherboard first.");
//        return;
//    }

//    var compatibleDisks = diskEntities.Where(d => selectedMotherboard.DiskSockets.Contains(d.DiskSocket)).ToList();

//    Console.WriteLine("\nCompatible Disks:");
//    compatibleDisks.Select((d, index) => new { Index = index + 1, Disk = d })
//        .ToList()
//        .ForEach(item => Console.WriteLine($"{item.Index}. Disk: {item.Disk.DiskName}, " +
//            $"Capacity: {item.Disk.DiskCapacity}GB, " +
//            $"Read Speed: {item.Disk.DiskReading}MB/s, " +
//            $"Write Speed: {item.Disk.DiskWrite}MB/s, " +
//            $"Price: {item.Disk.ItemCost}"));

//    Console.Write("\nEnter the number of the disk you want to add to your setup (0 to cancel): ");
//    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleDisks.Count)
//    {
//        yourSetup.Add(compatibleDisks[choice - 1]);
//        Console.WriteLine("Disk added to your setup.");
//    }
//    else if (choice != 0)
//    {
//        Console.WriteLine("Invalid choice. No disk added.");
//    }
//}

//public void GraphicsCards(List<GraphicsCardEntity> graphicsCardEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup)
//{
//    if (selectedMotherboard == null)
//    {
//        Console.WriteLine("Please select a motherboard first.");
//        return;
//    }

//    var compatibleGraphicsCards = graphicsCardEntities.Where(g => selectedMotherboard.GraphicsSockets.Contains(g.GraphicsSocket)).ToList();

//    Console.WriteLine("\nCompatible Graphics Cards:");
//    compatibleGraphicsCards.Select((g, index) => new { Index = index + 1, GPU = g })
//        .ToList()
//        .ForEach(item => Console.WriteLine($"{item.Index}. GPU: {item.GPU.GraphicsName}, " +
//            $"VRAM: {item.GPU.GraphicsRam}GB, " +
//            $"Core Frequency: {item.GPU.GraphicsCoreFrequency}MHz, " +
//            $"Power: {item.GPU.RecommendedGraphicsPower}W, " +
//            $"Price: {item.GPU.ItemCost}"));

//    Console.Write("\nEnter the number of the graphics card you want to add to your setup (0 to cancel): ");
//    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= compatibleGraphicsCards.Count)
//    {
//        yourSetup.Add(compatibleGraphicsCards[choice - 1]);
//        Console.WriteLine("Graphics card added to your setup.");
//    }
//    else if (choice != 0)
//    {
//        Console.WriteLine("Invalid choice. No graphics card added.");
//    }
//}

//public void PowerSupplies(List<PowerSupplyEntity> powerSupplies, List<object> yourSetup)
//{
//    Console.WriteLine("\nAvailable Power Supplies:");
//    powerSupplies.Select((p, index) => new { Index = index + 1, PowerSupply = p })
//        .ToList()
//        .ForEach(item => Console.WriteLine($"{item.Index}. Power Supply: {item.PowerSupply.PowerName}, " +
//            $"Wattage: {item.PowerSupply.PowerValue}, " +
//            $"Price: {item.PowerSupply.ItemCost}"));

//    Console.Write("\nEnter the number of the power supply you want to add to your setup (0 to cancel): ");
//    if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= powerSupplies.Count)
//    {
//        yourSetup.Add(powerSupplies[choice - 1]);
//        Console.WriteLine("Power supply added to your setup.");
//    }
//    else if (choice != 0)
//    {
//        Console.WriteLine("Invalid choice. No power supply added.");
//    }
//}