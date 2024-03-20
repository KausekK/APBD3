using System;
using LAB3.Exceptions;

namespace LAB3.Containers;

public class CoolingContainer : Container
{
    private string _productType;
    private double _containerTemp;

    public CoolingContainer(double cargoWeight, double height, double containerWeight, double depth, double maxPayload,
        ContainerType type, string productType, double containerTemp) :
        base(cargoWeight, height, containerWeight, depth, maxPayload, ContainerType.Cooling)
    {
        _productType = productType;
        _containerTemp = containerTemp;
    }

    public override void Load(double cargoWeight, string serialNumber)
    {
        if (cargoWeight > MaxPayload)
        {
            throw new OverfillException("Attempted to load cargo exceeding maximum payload.");
        }

        if (CargoWeight == 0 || _productType == null)
        {
            CargoWeight = cargoWeight;
            _productType = ""; 
        }
        else if (_productType != "")
        {
            throw new InvalidOperationException("Container already contains a different type of product.");
        }
        else
        {
            if (Enum.TryParse(_productType, out PossibleProducts product))
            {
                if (_containerTemp < RequiredTemperature(product))
                {
                    throw new InvalidOperationException(
                        $"Container temperature is too low for {_productType} products.");
                }
            }
            else
            {
                throw new ArgumentException($"Unknown product type: {_productType}");
            }


            base.Load(cargoWeight, serialNumber);
        }
    }

    private double RequiredTemperature(PossibleProducts productType)
    {
        switch (productType)
        {
            case PossibleProducts.Banana:
                return 13.3; 
            case PossibleProducts.Chocolate:
                return 18.0; 
            case PossibleProducts.Fish:
                return 2.0; 
            case PossibleProducts.Meat:
                return -15.0;
            case PossibleProducts.IceCream:
                return -18.0;
            case PossibleProducts.FrozenPizza:
                return -30.0; 
            case PossibleProducts.Cheese:
                return 7.2; 
            case PossibleProducts.Sausages:
                return 5.0;
            case PossibleProducts.Butter:
                return 20.5;
            case PossibleProducts.Eggs:
                return 19.0; 
            default:
                throw new ArgumentException("Unknown product type");
        }
    }
}