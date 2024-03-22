using System;
using System.Collections.Generic;
using LAB3.Containers;

namespace LAB3;

public class Ship
{
    public double MaxWeight { get; }
    public int MaxContainers { get; }
    public double  MaxSpeed { get; }
    public List<Container> Containers { get; }

    public Ship(double maxWeight, int maxContainers, double maxSpeed)
    {
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        MaxSpeed = maxSpeed;
        Containers = new List<Container>();
    }
    
    public void AddContainer(Container container)
    {
        if (Containers.Count < MaxContainers)
        {
            Containers.Add(container);
            Console.WriteLine("Container added to the ship.");
        }
        else
        {
            Console.WriteLine("Cannot add container. Maximum container capacity reached.");
        }
    }

    public void DisplayAllContainers()
    {
        Console.WriteLine("Containers on the ship:");
        foreach (var container in Containers)
        {
            Console.WriteLine(container);
        }
    }
    public bool RemoveContainer(string serialNumber)
    {
        Container containerToRemove = Containers.Find(container => container.SerialNumber == serialNumber);

        if (containerToRemove != null)
        {
            Containers.Remove(containerToRemove);
            Console.WriteLine($"Container with serial number {serialNumber} removed from the ship.");
            return true; 
        }
        Console.WriteLine($"Container with serial number {serialNumber} not found on the ship.");
        return false;
    }
    
    public bool UnloadContainer(string serialNumber)
    {
        Container containerToUnload = Containers.Find(container => container.SerialNumber == serialNumber);

        if (containerToUnload != null)
        {
            containerToUnload.Unload();
            Containers.Remove(containerToUnload);
            Console.WriteLine($"Container with serial number {serialNumber} unloaded from the ship.");
            return true; 
        }
        Console.WriteLine($"Container with serial number {serialNumber} not found on the ship.");
        return false;
    }
    public bool ReplaceContainer(string serialNumber, Container newContainer)
    {
        Container containerToReplace = Containers.Find(container => container.SerialNumber == serialNumber);

        if (containerToReplace != null)
        {
            Containers.Remove(containerToReplace);
            Console.WriteLine($"Container with serial number {serialNumber} replaced on the ship.");

            AddContainer(newContainer);
            return true; 
        }

        Console.WriteLine($"Container with serial number {serialNumber} not found on the ship. Cannot replace.");
        return false; 
    }
    
    public static bool TransferContainer(Ship fromShip, Ship toShip, string serialNumber)
    {
        Container containerToTransfer = fromShip.Containers.Find(container => container.SerialNumber == serialNumber);

        if (containerToTransfer != null)
        {
            fromShip.Containers.Remove(containerToTransfer);
            Console.WriteLine($"Container with serial number {serialNumber} transferred from Ship A to Ship B.");

            toShip.Containers.Add(containerToTransfer);
            return true; 
        }
        Console.WriteLine($"Container with serial number {serialNumber} not found on Ship A. Cannot transfer.");
        return false; 
    }
    public override string ToString()
    {
        string shipInfo = $"Ship Max Weight: {MaxWeight} tons, Max Containers: {MaxContainers}, Max Speed: {MaxSpeed} knots\n";
        shipInfo += "Containers on the ship:\n";

        foreach (var container in Containers)
        {
            shipInfo += container + "\n";
        }

        return shipInfo;
    }
}
