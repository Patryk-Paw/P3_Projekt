using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using Domain.Entities;

public class Add
{
    private void SaveJsonData<T>(List<T> data, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void Motherboard(List<MotherboardEntity> motherboardEntities)
    {
        Console.WriteLine("Enter Motherboard details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Chipset: ");
        string chipset = Console.ReadLine();
        Console.Write("Processor Socket(s) (comma-separated): ");
        var processorSockets = Console.ReadLine().Split(',').Select(s => s.Trim().ToUpper()).ToList();
        Console.Write("RAM Socket(s) (comma-separated): ");
        var ramSockets = Console.ReadLine().Split(',').Select(s => s.Trim().ToUpper()).ToList();
        Console.Write("RAM Type: ");
        string ramType = Console.ReadLine().ToUpper();
        Console.Write("Max RAM Capacity (GB): ");
        int.TryParse(Console.ReadLine(), out int maxRamCapacity);
        Console.Write("Max RAM Slots: ");
        int.TryParse(Console.ReadLine(), out int maxRamSlots);
        Console.Write("Disk Socket(s) (comma-separated): ");
        var diskSockets = Console.ReadLine().Split(',').Select(s => s.Trim().ToUpper()).ToList();
        Console.Write("Graphics Socket(s) (comma-separated): ");
        var graphicsSockets = Console.ReadLine().Split(',').Select(s => s.Trim().ToUpper()).ToList();
        Console.Write("Motherboard Standard: ");
        string motherboardStandard = Console.ReadLine().ToUpper();
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Quantity: ");
        int.TryParse(Console.ReadLine(), out int quantity);

        var newMotherboard = new MotherboardEntity(name, price, quantity, name, chipset, processorSockets, ramSockets, ramType, maxRamCapacity, diskSockets, graphicsSockets, motherboardStandard, maxRamSlots)
        {
            MotherboardId = motherboardEntities.Count + 1
        };

        motherboardEntities.Add(newMotherboard);
        SaveJsonData(motherboardEntities, "../../../../JSONData/DataMotherboardEntities.json");
        Console.WriteLine("Motherboard added successfully!");
    }

    public void Processor(List<ProcessorEntity> processorEntities)
    {
        Console.WriteLine("Enter Processor details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Socket: ");
        string socket = Console.ReadLine().ToUpper();
        Console.Write("Cores: ");
        double.TryParse(Console.ReadLine(), out double cores);
        Console.Write("Frequency (GHz): ");
        double.TryParse(Console.ReadLine(), out double frequency);
        Console.Write("Threads: ");
        double.TryParse(Console.ReadLine(), out double threads);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Quantity: ");
        int.TryParse(Console.ReadLine(), out int quantity);

        var newProcessor = new ProcessorEntity(name, price, quantity, true, name, socket, cores, frequency, threads)
        {
            ProcessorId = processorEntities.Count + 1
        };

        processorEntities.Add(newProcessor);
        SaveJsonData(processorEntities, "../../../../JSONData/DataProcessorEntities.json");
        Console.WriteLine("Processor added successfully!");
    }

    public void RAM(List<RamEntity> ramEntities)
    {
        Console.WriteLine("Enter RAM details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Type: ");
        string type = Console.ReadLine().ToUpper();
        Console.Write("Socket: ");
        string socket = Console.ReadLine().ToUpper();
        Console.Write("Capacity (GB): ");
        double.TryParse(Console.ReadLine(), out double capacity);
        Console.Write("Frequency (MHz): ");
        double.TryParse(Console.ReadLine(), out double frequency);
        Console.Write("Number of Modules: ");
        double.TryParse(Console.ReadLine(), out double modules);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Quantity: ");
        int.TryParse(Console.ReadLine(), out int quantity);

        var newRAM = new RamEntity(name, price, quantity, true, ramEntities.Count + 1, name, type, socket, capacity, frequency, modules);

        ramEntities.Add(newRAM);
        SaveJsonData(ramEntities, "../../../../JSONData/DataRamEntities.json");
        Console.WriteLine("RAM added successfully!");
    }

    public void Disk(List<DiskEntity> diskEntities)
    {
        Console.WriteLine("Enter Disk details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Capacity (GB): ");
        double.TryParse(Console.ReadLine(), out double capacity);
        Console.Write("Format: ");
        string format = Console.ReadLine().ToUpper();
        Console.Write("Read Speed (MB/s): ");
        double.TryParse(Console.ReadLine(), out double readSpeed);
        Console.Write("Write Speed (MB/s): ");
        double.TryParse(Console.ReadLine(), out double writeSpeed);
        Console.Write("Socket: ");
        string socket = Console.ReadLine().ToUpper();
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Quantity: ");
        int.TryParse(Console.ReadLine(), out int quantity);

        var newDisk = new DiskEntity(name, price, quantity, name, capacity, format, readSpeed, writeSpeed, socket)
        {
            DiskID = diskEntities.Count + 1
        };

        diskEntities.Add(newDisk);
        SaveJsonData(diskEntities, "../../../../JSONData/DataDiskEntities.json");
        Console.WriteLine("Disk added successfully!");
    }

    public void GraphicsCard(List<GraphicsCardEntity> graphicsCardEntities)
    {
        Console.WriteLine("Enter Graphics Card details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Socket: ");
        string socket = Console.ReadLine().ToUpper();
        Console.Write("Core Frequency (MHz): ");
        double.TryParse(Console.ReadLine(), out double coreFrequency);
        Console.Write("Memory Frequency (MHz): ");
        double.TryParse(Console.ReadLine(), out double memoryFrequency);
        Console.Write("Recommended Power (W): ");
        double.TryParse(Console.ReadLine(), out double recommendedPower);
        Console.Write("VRAM (GB): ");
        double.TryParse(Console.ReadLine(), out double vram);
        Console.Write("Number of Cooling Fans: ");
        double.TryParse(Console.ReadLine(), out double coolingFans);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Quantity: ");
        int.TryParse(Console.ReadLine(), out int quantity);

        var newGraphicsCard = new GraphicsCardEntity(name, price, quantity, name, socket, coreFrequency, memoryFrequency, recommendedPower, vram, coolingFans)
        {
            GraphicsID = graphicsCardEntities.Count + 1
        };

        graphicsCardEntities.Add(newGraphicsCard);
        SaveJsonData(graphicsCardEntities, "../../../../JSONData/DataGraphicsCardEntities.json");
        Console.WriteLine("Graphics Card added successfully!");
    }

    public void PowerSupply(List<PowerSupplyEntity> powerSupplies)
    {
        Console.WriteLine("Enter Power Supply details:");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Standard: ");
        string standard = Console.ReadLine().ToUpper();
        Console.Write("Wattage: ");
        string wattage = Console.ReadLine().ToUpper();
        Console.Write("Certificate: ");
        string certificate = Console.ReadLine().ToUpper();
        Console.Write("Power Socket(s) (comma-separated): ");
        var powerSockets = Console.ReadLine().Split(',').Select(s => s.Trim().ToUpper()).ToList();
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);
        Console.Write("Quantity: ");
        int.TryParse(Console.ReadLine(), out int quantity);

        var newPowerSupply = new PowerSupplyEntity(name, price, quantity, standard, wattage, certificate, powerSockets)
        {
            PowerId = powerSupplies.Count + 1
        };

        powerSupplies.Add(newPowerSupply);
        SaveJsonData(powerSupplies, "../../../../JSONData/DataPowerSupplies.json");
        Console.WriteLine("Power Supply added successfully!");
    }
}
