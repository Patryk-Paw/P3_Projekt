using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface I_Add
    {
        void Motherboard(List<MotherboardEntity> motherboardEntities);
        void Processor(List<ProcessorEntity> processorEntities);
        void RAM(List<RamEntity> ramEntities);
        void Disk(List<DiskEntity> diskEntities);
        void GraphicsCard(List<GraphicsCardEntity> graphicsCardEntities);
        void PowerSupply(List<PowerSupplyEntity> powerSupplies);
    }

