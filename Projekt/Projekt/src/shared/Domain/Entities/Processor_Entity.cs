
namespace Domain.Entities;

internal class Processor_Entity : Sprzet_Entity
{
    public int ProcessorId { get; set; }
    public string? ProcessorName { get; set; }
    public string? ProcessorSlot { get; set; }
    public double ProcessorCores { get; set; }
    public double ProcessorFrequency { get; set; }
    public double ProcessorThreads { get; set; }
}
