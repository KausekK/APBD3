

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
  
    public static Container CreateContainer(ContainerType type, double cargoWeight, double height, double containerWeight, double depth, double maxPayload, string productType = null, double containerTemperature = 0, int pressure = 0 , bool isDangerous = false)
    {
        switch (type)
        {
            case ContainerType.Cooling:
                return new CoolingContainer(cargoWeight, height, containerWeight, depth, maxPayload,type ,productType, containerTemperature);
            case ContainerType.Gas:
                return new GasContainer(cargoWeight, height, containerWeight, depth, maxPayload, type, pressure);
            case ContainerType.Liquids:
                return new LiquidContainer(cargoWeight, height, containerWeight, depth, maxPayload, isDangerous);
            default:
                throw new ArgumentException("Invalid container type");
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
    public override string ToString()
    {
        return $"Serial Number: {SerialNumber}, Cargo Weight: {CargoWeight}, Height: {Height}, Container Weight: {ContainerWeight}, Depth: {Depth}, Max Payload: {MaxPayload}";
    }
    
}