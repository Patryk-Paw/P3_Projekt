namespace Domain.Entities;

internal class Sprzet_Entity
{
    public int ItemID { get; set; }
    public string? ItemName { get; set; }
    public string? ItemType { get; set; }
    public double ItemCost { get; set; }
    public int ItemQuantity { get; set; }
    public bool Accesibility { get; set; } 
}
