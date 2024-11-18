﻿using System.Text.Json;
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
List<PowerSupplyEntity> powerSupplies = JsonSerializer.Deserialize<List<PowerSupplyEntity>>(File.ReadAllText("JSONData/DataPowerSupplies.json"), options);
List<DiskEntity> diskEntities = JsonSerializer.Deserialize<List<DiskEntity>>(File.ReadAllText("JSONData/DataDiskEntities.json"), options);
List<MotherboardEntity> motherboardEntities = JsonSerializer.Deserialize<List<MotherboardEntity>>(File.ReadAllText("JSONData/DataMotherboardEntities.json"), options);
List<RamEntity> ramEntities = JsonSerializer.Deserialize<List<RamEntity>>(File.ReadAllText("JSONData/DataRamEntities.json"), options);
List<GraphicsCardEntity> graphicsCardEntities = JsonSerializer.Deserialize<List<GraphicsCardEntity>>(File.ReadAllText("JSONData/DataGraphicsCardEntities.json"), options);
List<ProcessorEntity> processorEntities = JsonSerializer.Deserialize<List<ProcessorEntity>>(File.ReadAllText("JSONData/DataProcessorEntities.json"), options);

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
    Console.WriteLine("0. Exit");

    Console.Write("\nEnter your choice: ");
    int number = Convert.ToInt32(Console.ReadLine());

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
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= motherboardEntities.Count)
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
            foreach (var gpu in graphicsCardEntities)
            {
                Console.WriteLine($"GPU: {gpu.GraphicsName}, VRAM: {gpu.GraphicsRam}GB, Core Frequency: {gpu.GraphicsCoreFrequency}MHz," +
                    $" Power: {gpu.RecommendedGraphicsPower}W, Price: {gpu.ItemCost}");
            }
            break;

        case 3:
            foreach (var processor in processorEntities)
            {
                Console.WriteLine($"Processor: {processor.ProcessorName}, Cores: {processor.ProcessorCores}, Threads: {processor.ProcessorThreads}," +
                    $" Frequency: {processor.ProcessorFrequency}GHz, Price: {processor.ItemCost}");
            }
            break;

        case 4:
            foreach (var ram in ramEntities)
            {
                Console.WriteLine($"RAM: {ram.RamName}, Capacity: {ram.RamCapacity}GB, Frequency: " +
                    $"{ram.RamFrequency}MHz, Modules: {ram.ModulesNumber}, Price: {ram.ItemCost}");
            }
            break;

        case 5:
            foreach (var disk in diskEntities)
            {
                Console.WriteLine($"Disk: {disk.DiskName}, Capacity: {disk.DiskCapacity}GB, Read Speed: {disk.DiskReading}MB/s," +
                    $" Write Speed: {disk.DiskWrite}MB/s, Price: {disk.ItemCost}");
            }
            break;

        case 6:
            foreach (var powerSupply in powerSupplies)
            {
                Console.WriteLine($"Power Supply: {powerSupply.PowerName}, Wattage: {powerSupply.PowerValue}, Price: {powerSupply.ItemCost}");
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
                foreach (var item in yourSetup)
                {
                    Console.WriteLine(item);
                }
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