
using System;
using LAB3.interfcaces;
using LAB3.Exceptions;

namespace LAB3.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _isDangerous;
    public LiquidContainer(double cargoWeight, double height, double containerWeight, double depth, double maxPayload, bool isDangerous ) : 
        base(cargoWeight, height, containerWeight, depth, maxPayload, ContainerType.Liquids )
    {
        _isDangerous = isDangerous;
    }

    public override void Load(double cargoWeight, string serialNumber)
    {
        if (_isDangerous && cargoWeight > MaxPayload / 2)
        {
            throw new OverfillException("Cannot load dangerous cargo exceeding 50 % of max payload.");
        }

        if (!_isDangerous)
        {
            base.Load(cargoWeight * 0.9, serialNumber);
        }
        else 
        {
            Warning(serialNumber);
        }
    }


    public void Warning(string serialNumber)
    {
        Console.WriteLine("Dangerous situation with container: " + serialNumber);
    }
}