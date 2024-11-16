namespace Domain.Entities;

public class GraphicsCardEntity : HardwareEntity
{
    //Parameters
    private static int nextID = 0;
    private static int classID = 3;
    public int? GraphicsID { get; set; }
    public string? GraphicsName { get; set; }
    public string? GraphicsSocket { get; set; }
    public double? GraphicsCoreFrequency { get; set; }
    public double? GraphicsMemoryFrequency { get; set; }
    public double? RecommendedGraphicsPower { get; set; }
    public double? GraphicsRam { get; set; }
    public double? CoolingNumber { get; set; }

    // Parameterless constructor for deserialization
    public GraphicsCardEntity()
    {
        ClassID = classID;
        ItemType = "Graphics Card";
    }

    //Constructor
    public GraphicsCardEntity(string itemName, double itemCost, int itemQuantity, string graphicsName,
                              string graphicsSocket, double? graphicsCoreFrequency, double? graphicsMemoryFrequency,
                              double? recommendedGraphicsPower, double? graphicsRam, double? coolingNumber)
    {
        // Initialize base class (HardwareEntity) properties
        ClassID = classID;
        ItemName = itemName;
        ItemType = "Graphics Card";
        ItemCost = itemCost;
        ItemQuantity = itemQuantity;
        Accesibility = itemQuantity >= 1;

        // Initialize GraphicsCardEntity specific properties
        GraphicsID = ++nextID;
        GraphicsName = graphicsName;
        GraphicsSocket = graphicsSocket;
        GraphicsCoreFrequency = graphicsCoreFrequency;
        GraphicsMemoryFrequency = graphicsMemoryFrequency;
        RecommendedGraphicsPower = recommendedGraphicsPower;
        GraphicsRam = graphicsRam;
        CoolingNumber = coolingNumber;
    }
}