

using LAB3.interfcaces;

namespace LAB3.Containers;

public class Container : IContainer
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }

    public Container(double cargoWeight, double height)
    {
        CargoWeight = cargoWeight;
        Height = height;
    }

    private double _cargoWeight;
    private double _height;

    public double GetCargoWeight()
    {
        return _cargoWeight;
    }

    public void SetCargoWeight(double value)
    {
        _cargoWeight = value;
    }

    public double GetHeight()
    {
        return _height;
    }

    public void SetHeight(double value)
    {
        _height = value;
    }
}