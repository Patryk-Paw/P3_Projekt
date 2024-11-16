namespace Domain.Entities;

public class PowerSupplyEntity : HardwareEntity
{
    // Paremeters
    private static int nextID = 0;
    private static int classID = 6;
    public int? PowerId { get; set; }
    public string? PowerName { get; set; }
    public string? PowerStandard {  get; set; }
    public string? PowerValue { get; set; }
    public string? PowerCertificate { get; set; }
    public IEnumerable<string>? PowerSockets { get; set; }

    // Parameterless constructor for deserialization
    public PowerSupplyEntity()
    {
        ClassID = classID;
        ItemType = "Power Supply";
    }

    //Constructor
    public PowerSupplyEntity(string itemName, double itemCost, int itemQuantity,
                             string powerName, string powerStandard, string powerValue,
                             string powerCertificate, IEnumerable<string> powerSockets)
    {
        // Initialize base class properties
        ClassID = classID;
        ItemName = itemName;
        ItemType = "Power Supply";
        ItemCost = itemCost;
        ItemQuantity = itemQuantity;
        Accesibility = itemQuantity >= 1;

        // Initialize PowerSupplyEntity specific properties
        PowerId = ++nextID;
        PowerName = powerName;
        PowerStandard = powerStandard;
        PowerValue = powerValue;
        PowerCertificate = powerCertificate;
        PowerSockets = powerSockets;
    }
}


