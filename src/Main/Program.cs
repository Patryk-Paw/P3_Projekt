using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;
using Domain.Entities;


// Power Supply
// How to read / serialize JSON file

string PSjson = File.ReadAllText("JSONData/DataPowerSupplies.json");

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    ReferenceHandler = ReferenceHandler.Preserve,
    WriteIndented = true
};

List<PowerSupplyEntity> powerSupplies = JsonSerializer.Deserialize<List<PowerSupplyEntity>>(PSjson, options);


// How to show in console

foreach (var powerSupply in powerSupplies)
{
    Console.WriteLine($"Power Supply: {powerSupply.PowerName}, Wattage: {powerSupply.PowerValue}");
}

// Disk

string Djson = File.ReadAllText("JSONData/DataDiskEntities.json");

List<DiskEntity> diskEntities = JsonSerializer.Deserialize<List<DiskEntity>>(Djson, options);

foreach (var disk in diskEntities)
{
    Console.WriteLine($"Disk: {disk.DiskName}, Capacity: {disk.DiskCapacity}GB, Read Speed: {disk.DiskReading}MB/s, Write Speed: {disk.DiskWrite}MB/s");
}

// Motherboard

string MBjson = File.ReadAllText("JSONData/DataMotherboardEntities.json");

List<MotherboardEntity> motherboardEntities = JsonSerializer.Deserialize<List<MotherboardEntity>>(MBjson, options);

foreach (var motherboard in motherboardEntities)
{
    Console.WriteLine($"Motherboard: {motherboard.MotherboardName}, Chipset: {motherboard.MotherboardChipset}, RAM Type: {motherboard.RamType}, Max RAM: {motherboard.MaxRamCapacity}GB");
}

// Ram 

string Rjson = File.ReadAllText("JSONData/DataRamEntities.json");

List<RamEntity> ramEntities = JsonSerializer.Deserialize<List<RamEntity>>(Rjson, options);

foreach (var ram in ramEntities)
{
    Console.WriteLine($"RAM: {ram.RamName}, Capacity: {ram.RamCapacity}GB, Frequency: {ram.RamFrequency}MHz, Modules: {ram.ModulesNumber}");
}

// Graphics Card

string GCjson = File.ReadAllText("JSONData/DataGraphicsCardEntities.json");

List<GraphicsCardEntity> graphicsCardEntities = JsonSerializer.Deserialize<List<GraphicsCardEntity>>(GCjson, options);

foreach (var gpu in graphicsCardEntities)
{
    Console.WriteLine($"GPU: {gpu.GraphicsName}, VRAM: {gpu.GraphicsRam}GB, Core Frequency: {gpu.GraphicsCoreFrequency}MHz, Power: {gpu.RecommendedGraphicsPower}W");
}

// Processor 

string Pjson = File.ReadAllText("JSONData/DataProcessorEntities.json");

List<ProcessorEntity> processorEntities = JsonSerializer.Deserialize<List<ProcessorEntity>>(Pjson, options);

foreach (var processor in processorEntities)
{
    Console.WriteLine($"Processor: {processor.ProcessorName}, Cores: {processor.ProcessorCores}, Threads: {processor.ProcessorThreads}, Frequency: {processor.ProcessorFrequency}GHz");
}