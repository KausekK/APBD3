
using System;
using LAB3;
using LAB3.Containers;

var coolingContainer = Container.CreateContainer(ContainerType.Cooling, 500, 2.5, 200, 2, 1000, "Chocolate", 10);
            var gasContainer = Container.CreateContainer(ContainerType.Gas, 700, 3, 250, 3, 1200, pressure: 50);
            var liquidContainer = Container.CreateContainer(ContainerType.Liquids, 800, 3.5, 300, 3.5, 1500, isDangerous: true);

            // Tworzenie statków
            var shipA = new Ship(2000, 100, 25);
            var shipB = new Ship(3000, 150, 30);

            // Dodawanie kontenerów do statków
            shipA.AddContainer(coolingContainer);
            shipA.AddContainer(gasContainer);
            shipB.AddContainer(liquidContainer);

            // Wyświetlanie wszystkich kontenerów na statkach
            Console.WriteLine("Containers on Ship A:");
            shipA.DisplayAllContainers();

            Console.WriteLine("\nContainers on Ship B:");
            shipB.DisplayAllContainers();

            // Usuwanie kontenera z statku
            string containerToRemoveSerialNumber = coolingContainer.SerialNumber;
            shipA.RemoveContainer(containerToRemoveSerialNumber);

            // Wyświetlanie zaktualizowanej listy kontenerów na statku
            Console.WriteLine("\nContainers on Ship A after removal:");
            shipA.DisplayAllContainers();

            // Rozładowywanie kontenera na statku
            string containerToUnloadSerialNumber = liquidContainer.SerialNumber;
            shipB.UnloadContainer(containerToUnloadSerialNumber);

            // Wyświetlanie zaktualizowanej listy kontenerów na statku
            Console.WriteLine("\nContainers on Ship B after unloading:");
            shipB.DisplayAllContainers();

            // Zastąpienie kontenera na statku innym kontenerem
            string containerToReplaceSerialNumber = gasContainer.SerialNumber;
            var newContainer = Container.CreateContainer(ContainerType.Gas, 1000, 3.2, 300, 3.2, 1400, pressure: 40);
            shipB.ReplaceContainer(containerToReplaceSerialNumber, newContainer);

            // Wyświetlanie zaktualizowanej listy kontenerów na statku
            Console.WriteLine("\nContainers on Ship B after replacement:");
            shipB.DisplayAllContainers();

            // Przeniesienie kontenera między statkami
            string containerToTransferSerialNumber = coolingContainer.SerialNumber;
            Ship.TransferContainer(shipA, shipB, containerToTransferSerialNumber);

            // Wyświetlanie zaktualizowanych list kontenerów na statkach po przeniesieniu
            Console.WriteLine("\nContainers on Ship A after transfer:");
            shipA.DisplayAllContainers();

            Console.WriteLine("\nContainers on Ship B after transfer:");
            shipB.DisplayAllContainers();
            
            // Wyświetlanie informacji o statkach
            Console.WriteLine("\nShip A information:");
            Console.WriteLine(shipA);

            Console.WriteLine("\nShip B information:");
            Console.WriteLine(shipB);
      
        