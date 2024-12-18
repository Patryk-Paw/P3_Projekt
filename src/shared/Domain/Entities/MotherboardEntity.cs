namespace Domain.Entities;

public class MotherboardEntity : HardwareEntity
{
    // Parameters
    private static int nextID = 0;
    private static int classID = 1;
    public int? MotherboardId { get; set; }
    public string? MotherboardName { get; set; }
    public string? MotherboardChipset { get; set; }
    public string? MotherboardStandard { get; set; }
    public IEnumerable<string>? ProcessorSockets { get; set; }
    public IEnumerable<string>? RamSockets { get; set; }
    public IEnumerable<string>? DiskSockets { get; set; }
    public IEnumerable<string>? GraphicsSockets { get; set; }
    public string? RamType { get; set; }
    public int? MaxRamCapacity { get; set; }
    public int? MaxRamSlots { get; set; }

    // Parameterless constructor for deserialization
    public MotherboardEntity()
    {
        ClassID = classID;
        ItemType = "Motherboard";
    }

    public MotherboardEntity(string itemName, double itemCost, int itemQuantity,
                             string motherboardName, string motherboardChipset,
                             IEnumerable<string> processorSocket, IEnumerable<string> ramSockets,
                             string ramType, int maxRamCapacity, IEnumerable<string> diskSockets,
                             IEnumerable<string> graphicsSockets, string motherboardStandard, int maxRamSlots)
    {
        // Initialize base class (HardwareEntity) properties
        ClassID = classID;
        ItemName = itemName;
        ItemType = "Motherboard";
        ItemCost = itemCost;
        ItemQuantity = itemQuantity;
        Accesibility = itemQuantity >= 1;

        // Initialize MotherboardEntity specific properties
        MotherboardId = ++nextID;
        MotherboardName = motherboardName;
        MotherboardChipset = motherboardChipset;
        ProcessorSockets = processorSocket;
        RamSockets = ramSockets;
        RamType = ramType;
        MaxRamCapacity = maxRamCapacity;
        DiskSockets = diskSockets;
        GraphicsSockets = graphicsSockets;
        MotherboardStandard = motherboardStandard;
        MaxRamSlots = maxRamSlots;
    }
}