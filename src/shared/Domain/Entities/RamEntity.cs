namespace Domain.Entities;

public class RamEntity : HardwareEntity
{
    // Parameters
    private static int nextID = 0;
    private static int classID = 4;
    public int? RamId { get; set; }
    public string? RamName { get; set; }
    public string? RamType { get; set; }
    public string? RamSocket { get; set; }
    public double? RamCapacity { get; set; }
    public double? RamFrequency { get; set; }
    public double? ModulesNumber { get; set; }

    // Parameterless constructor for deserialization
    public RamEntity()
    {
        ClassID = classID;
        ItemType = "RAM";
    }

    // Constructor
    public RamEntity(string itemName, double itemCost, int itemQuantity, bool accessibility,
                     int ramID, string ramName, string ramType, string ramSocket,
                     double ramCapacity, double ramFrequency, double modulesNumber)
    {
        // Initialize base class properties
        ClassID = classID;
        ItemName = itemName;
        ItemType = "RAM";
        ItemCost = itemCost;
        ItemQuantity = itemQuantity;
        Accesibility = itemQuantity >= 1;

        // Initialize RamEntity specific properties
        RamId = ++nextID;
        RamName = ramName;
        RamType = ramType;
        RamSocket = ramSocket;
        RamCapacity = ramCapacity;
        RamFrequency = ramFrequency;
        ModulesNumber = modulesNumber;
    }
}