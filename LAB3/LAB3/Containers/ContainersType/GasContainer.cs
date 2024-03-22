using System;
using LAB3.Exceptions;
using LAB3.interfcaces;

namespace LAB3.Containers;

public class GasContainer : Container, IHazardNotifier
{
    private int _pressure;
    public GasContainer(double cargoWeight, double height, double containerWeight, double depth, double maxPayload, ContainerType type, int pressure) : 
        base(cargoWeight, height, containerWeight, depth, maxPayload, ContainerType.Gas)
    {
        _pressure = pressure;
    }

    public override void Unload()
    {
        CargoWeight *= 0.05; 
    }

    public void Warning(string serialNumber)
    {
        Console.WriteLine("Dangerous situation with container: " + serialNumber);
    }
    public override void Load(double cargoWeight, string serialNumber)
    {
        if (cargoWeight > MaxPayload)
        {
            throw new OverfillException("Attempted to load cargo exceeding maximum payload.");
        }

        base.Load(cargoWeight,serialNumber);
    }

}