

using System;
using LAB3.Exceptions;
using LAB3.interfcaces;

namespace LAB3.Containers;

public abstract class Container : IContainer
{

    private static int NextSerialNumber=1;
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double ContainerWeight { get; set; }
    public double Depth { get; set; }

    public string SerialNumber { get;  set; }
    public double MaxPayload { get; set; }

    protected Container(double cargoWeight, double height, double containerWeight, double depth, double maxPayload, ContainerType type)
    {
        CargoWeight = cargoWeight;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        SerialNumber = GenerateSerialNumber(type);
        MaxPayload = maxPayload;
    }

    public virtual void Unload()
    {
        CargoWeight = 0;
    }

    public virtual void Load(double cargoWeight, string serialNumber)
    {
        CargoWeight = cargoWeight;
        if (cargoWeight > MaxPayload)
        {
            throw new OverfillException();
        }
    }
  

    private string GenerateSerialNumber(ContainerType type)
    {
        string typeCode;

        if (type == ContainerType.Cooling)
        {
            typeCode = "C";
        }
        else if (type == ContainerType.Gas)
        {
            typeCode = "G";
        }
        else if (type == ContainerType.Liquids)
        {
            typeCode = "L";
        }
        else
        {
            throw new ArgumentException("Invalid container type");
        }
    
        string serialNumber = $"KON-{typeCode}-C-{NextSerialNumber}";
        NextSerialNumber++;
        return serialNumber;
    }

}