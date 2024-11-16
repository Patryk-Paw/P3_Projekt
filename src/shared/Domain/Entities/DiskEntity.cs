namespace Domain.Entities;

public class DiskEntity : HardwareEntity
{
    //Parameters
    private static int nextID = 0;
    private static int classID = 5;
    public int? DiskID { get; set; }
    public string? DiskName { get; set; }
    public double? DiskCapacity { get; set; }
    public string? DiskFormat { get; set; }
    public double? DiskReading { get; set; }
    public double? DiskWrite { get; set; }
    public string? DiskSocket { get; set; }

    // Parameterless constructor for deserialization
    public DiskEntity()
    {
        ClassID = classID;
        ItemType = "Disk";
    }

    public DiskEntity(string itemName, double itemCost, int itemQuantity,
                      string diskName, double diskCapacity, string diskFormat,
                      double diskReading, double diskWrite, string diskSocket)
    {
        // Initialize base class (HardwareEntity) properties
        ClassID = classID;
        ItemName = itemName;
        ItemType = "Disk";
        ItemCost = itemCost;
        ItemQuantity = itemQuantity;
        Accesibility = itemQuantity >= 1;

        // Initialize DiskEntity specific properties
        DiskID = ++nextID;
        DiskName = diskName;
        DiskCapacity = diskCapacity;
        DiskFormat = diskFormat;
        DiskReading = diskReading;
        DiskWrite = diskWrite;
        DiskSocket = diskSocket;
    }
}