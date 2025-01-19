using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
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
        Console.Write("RAM Type: ");
        string ramType = Console.ReadLine();
        Console.Write("Max RAM Capacity (GB): ");
        int.TryParse(Console.ReadLine(), out int maxRamCapacity);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        int? newMotherboardId = motherboardEntities.Count > 0 ? motherboardEntities.Max(Motherboard => Motherboard.MotherboardId) + 1 : 1;
        var newMotherboard = new MotherboardEntity
        {
            MotherboardId = newMotherboardId,
            ItemName = name,
            MotherboardName = name,
            MotherboardChipset = chipset,
            RamType = ramType,
            MaxRamCapacity = maxRamCapacity,
            ItemCost = price,
            ItemQuantity = 1,
            Accesibility = true
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
        string socket = Console.ReadLine();
        Console.Write("Cores: ");
        double.TryParse(Console.ReadLine(), out double cores);
        Console.Write("Frequency (GHz): ");
        double.TryParse(Console.ReadLine(), out double frequency);
        Console.Write("Threads: ");
        double.TryParse(Console.ReadLine(), out double threads);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        var newProcessor = new ProcessorEntity
        {
            ItemName = name,
            ProcessorName = name,
            ProcessorSocket = socket,
            ProcessorCores = cores,
            ProcessorFrequency = frequency,
            ProcessorThreads = threads,
            ItemCost = price,
            ItemQuantity = 1,
            Accesibility = true
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
        string type = Console.ReadLine();
        Console.Write("Socket: ");
        string socket = Console.ReadLine();
        Console.Write("Capacity (GB): ");
        double.TryParse(Console.ReadLine(), out double capacity);
        Console.Write("Frequency (MHz): ");
        double.TryParse(Console.ReadLine(), out double frequency);
        Console.Write("Number of Modules: ");
        double.TryParse(Console.ReadLine(), out double modules);
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        int? newRamId = ramEntities.Count > 0 ? ramEntities.Max(ram => ram.RamId) + 1 : 1;
        var newRAM = new RamEntity
        {
            RamId = newRamId,
            ItemName = name,
            RamName = name,
            RamType = type,
            RamSocket = socket,
            RamCapacity = capacity,
            RamFrequency = frequency,
            ModulesNumber = modules,
            ItemCost = price,
            ItemQuantity = 1,
            Accesibility = true
        };

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
        string format = Console.ReadLine();
        Console.Write("Read Speed (MB/s): ");
        double.TryParse(Console.ReadLine(), out double readSpeed);
        Console.Write("Write Speed (MB/s): ");
        double.TryParse(Console.ReadLine(), out double writeSpeed);
        Console.Write("Socket: ");
        string socket = Console.ReadLine();
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        var newDisk = new DiskEntity
        {
            ItemName = name,
            DiskName = name,
            DiskCapacity = capacity,
            DiskFormat = format,
            DiskReading = readSpeed,
            DiskWrite = writeSpeed,
            DiskSocket = socket,
            ItemCost = price,
            ItemQuantity = 1,
            Accesibility = true
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
        string socket = Console.ReadLine();
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

        var newGraphicsCard = new GraphicsCardEntity
        {
            ItemName = name,
            GraphicsName = name,
            GraphicsSocket = socket,
            GraphicsCoreFrequency = coreFrequency,
            GraphicsMemoryFrequency = memoryFrequency,
            RecommendedGraphicsPower = recommendedPower,
            GraphicsRam = vram,
            CoolingNumber = coolingFans,
            ItemCost = price,
            ItemQuantity = 1,
            Accesibility = true
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
        string standard = Console.ReadLine();
        Console.Write("Wattage: ");
        string wattage = Console.ReadLine();
        Console.Write("Certificate: ");
        string certificate = Console.ReadLine();
        Console.Write("Price: ");
        double.TryParse(Console.ReadLine(), out double price);

        var newPowerSupply = new PowerSupplyEntity
        {
            ItemName = name,
            PowerName = name,
            PowerStandard = standard,
            PowerValue = wattage,
            PowerCertificate = certificate,
            ItemCost = price,
            ItemQuantity = 1,
            Accesibility = true
        };

        powerSupplies.Add(newPowerSupply);
        SaveJsonData(powerSupplies, "../../../../JSONData/DataPowerSupplies.json");
        Console.WriteLine("Power Supply added successfully!");
    }
}