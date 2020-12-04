using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ül5;

namespace Tests
{
    [TestClass]
    public class TestDataTable
    {
        private List<Vechicles> _vechicles;
        [TestInitialize]
        public void Setup() {
            Console.WriteLine("CREATE TABLE Vechicles" +
                          "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                          "NrOfDoors TEXT, FuelTankCapacity TEXT, SaddleHeight TEXT, Type TEXT");
            _vechicles = new List<Vechicles>();
            _vechicles.Add(new Vechicles() {
                Id = "0",
                Manufacturer = "Ford",
                NrOfPassengers = "5",
                NrOfDoors = "5",
                FuelTankCapacity = "5l",
                SaddleHeight = null,
                Type = "Car"
            });
            _vechicles.Add(new Vechicles()
            {
                Id = "1",
                Manufacturer = "Scott",
                NrOfPassengers = "1",
                NrOfDoors = null,
                FuelTankCapacity = null,
                SaddleHeight = "5.2 cm",
                Type = "Bicycle"
            });
            _vechicles.Add(new Vechicles()
            {
                Id = "2",
                Manufacturer = "Audi",
                NrOfPassengers = "5",
                NrOfDoors = "5",
                FuelTankCapacity = "4l",
                SaddleHeight = null,
                Type = "Car"
            });
            _vechicles.Add(new Vechicles()
            {
                Id = "3",
                Manufacturer = "Merida",
                NrOfPassengers = "1",
                NrOfDoors = null,
                FuelTankCapacity = null,
                SaddleHeight = "5.5 cm",
                Type = "Bicycle"
            });
            foreach (var e in _vechicles) {
                Console.WriteLine("INSERT INTO Vechicles VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                    e.Id, e.Manufacturer,e.NrOfPassengers,e.NrOfDoors,e.FuelTankCapacity,e.SaddleHeight,e.Type);
            }
        }
        [TestMethod]
        public void VechiclesTableTest()
        {
            var data = VechiclesTable();
            Console.WriteLine("SELECT * from Vechicles");
            Assert.AreEqual(4,data.Count);
            Assert.AreEqual("Scott",data[1].Manufacturer);
            Assert.AreEqual(null, data[3].NrOfDoors);
        }
        [TestMethod]
        public void BicycleTableTest()
        {
            var data = BicycleTable();
            Console.WriteLine("SELECT * from Bicycle");
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("5.2 cm", data[0].SaddleHeight);
            Assert.AreEqual("1", data[0].NrOfPassengers);
        }
        [TestMethod]
        public void CarTableTest()
        {
            var data = CarTable();
            Console.WriteLine("SELECT * from Car");
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("Audi", data[1].Manufacturer);
            Assert.AreEqual("5", data[1].NrOfDoors);
        }

        private List<Vechicles> VechiclesTable() {
            return _vechicles;
        }

        private List<Car> CarTable() {
            Console.WriteLine("CREATE TABLE Car" +
                              "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                              " NrOfDoors TEXT, FuelTankCapacity TEXT");
            var data = VechiclesTable();
            List<Car> cars = new List<Car>();
            foreach (var d in data)
            {
                if (d.Type == "Car")
                {
                    cars.Add(new Car()
                    {
                        Id = d.Id,
                        Manufacturer = d.Manufacturer,
                        NrOfPassengers = d.NrOfPassengers,
                        NrOfDoors = d.NrOfDoors,
                        FuelTankCapacity = d.FuelTankCapacity
                    });
                    Console.WriteLine("INSERT INTO Car VALUES ({0}, {1}, {2}, {3}, {4})",
                        d.Id, d.Manufacturer, d.NrOfPassengers, d.NrOfDoors, d.FuelTankCapacity);
                }
            }
            return cars;
        }

        private List<Bicycle> BicycleTable() {
            Console.WriteLine("CREATE TABLE Bicycle" +
                              "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                              " SaddleHeight TEXT");
            var data = VechiclesTable();
            List<Bicycle> bicycles = new List<Bicycle>();
            foreach (var d in data)
            {
                if (d.Type == "Bicycle")
                {
                    bicycles.Add(new Bicycle()
                    {
                        Id = d.Id,
                        Manufacturer = d.Manufacturer,
                        NrOfPassengers = d.NrOfPassengers,
                        SaddleHeight = d.SaddleHeight
                    });
                    Console.WriteLine("INSERT INTO Bicycle VALUES ({0}, {1}, {2}, {3})",
                        d.Id, d.Manufacturer, d.NrOfPassengers, d.SaddleHeight);
                }
            }

            return bicycles;
        }
    }
}
