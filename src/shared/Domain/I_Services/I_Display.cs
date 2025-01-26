using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface I_Display
{
    void Motherboards(List<MotherboardEntity> motherboardEntities, ref MotherboardEntity selectedMotherboard, List<object> yourSetup, ref double? totalRamCapacity);
    void Processors(List<ProcessorEntity> processorEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup);
    void RAM(List<RamEntity> ramEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup, ref double? totalRamCapacity);
    void Disks(List<DiskEntity> diskEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup);
    void GraphicsCards(List<GraphicsCardEntity> graphicsCardEntities, MotherboardEntity selectedMotherboard, List<object> yourSetup);
    void PowerSupplies(List<PowerSupplyEntity> powerSupplies, List<object> yourSetup);
    void YourSetup(List<object> yourSetup, double? totalRamCapacity);
}
