namespace Domain.Entities;

public class ProcessorEntity : HardwareEntity
{
    // Parameters
    private static int nextID = 0;
    private static int classID = 2;
    public int? ProcessorId { get; set; }
    public string? ProcessorName { get; set; }
    public string? ProcessorSocket { get; set; }
    public double? ProcessorCores { get; set; }
    public double? ProcessorFrequency { get; set; }
    public double? ProcessorThreads { get; set; }

    // Parameterless constructor for deserialization
    public ProcessorEntity()
    {
        ClassID = classID;
        ItemType = "Processor";
    }

    // Constructor
    public ProcessorEntity(string itemName, double itemCost, int itemQuantity, bool accessibility,
                           string processorName, string processorSocket, double processorCores,
                           double processorFrequency, double processorThreads)
    {
        // Initialize base class properties
        ClassID = classID;
        ItemName = itemName;
        ItemType = "Processor";
        ItemCost = itemCost;
        ItemQuantity = itemQuantity;
        Accesibility = itemQuantity >= 1;

        // Initialize ProcessorEntity specific properties
        ProcessorId = ++nextID;
        ProcessorName = processorName;
        ProcessorSocket = processorSocket;
        ProcessorCores = processorCores;
        ProcessorFrequency = processorFrequency;
        ProcessorThreads = processorThreads;
    }
}