namespace Domain.Entities;

public class HardwareEntity
{
    //Parameters
    public int? ClassID { get; set; }
    public string? ItemName { get; set; }
    public string? ItemType { get; set; }
    public double? ItemCost { get; set; }
    public int? ItemQuantity { get; set; }
    public bool? Accesibility { get; set; }
}
