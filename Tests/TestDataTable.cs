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
        private List<Transportations> _transportations;
        [TestInitialize]
        public void Setup() {
            Console.WriteLine("CREATE TABLE Transportations" +
                          "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                          "NrOfDoors TEXT, FuelTankCapacity TEXT, SaddleHeight TEXT, Type TEXT");
            _transportations = new List<Transportations>();
            _transportations.Add(new Transportations() {
                Id = "0",
                Manufacturer = "Ford",
                NrOfPassengers = "5",
                NrOfDoors = "5",
                FuelTankCapacity = "5l",
                SaddleHeight = null,
                Type = "Car"
            });
            _transportations.Add(new Transportations()
            {
                Id = "1",
                Manufacturer = "Scott",
                NrOfPassengers = "1",
                NrOfDoors = null,
                FuelTankCapacity = null,
                SaddleHeight = "5.2 cm",
                Type = "Bicycle"
            });
            _transportations.Add(new Transportations()
            {
                Id = "2",
                Manufacturer = "Audi",
                NrOfPassengers = "5",
                NrOfDoors = "5",
                FuelTankCapacity = "4l",
                SaddleHeight = null,
                Type = "Car"
            });
            _transportations.Add(new Transportations()
            {
                Id = "3",
                Manufacturer = "Merida",
                NrOfPassengers = "1",
                NrOfDoors = null,
                FuelTankCapacity = null,
                SaddleHeight = "5.5 cm",
                Type = "Bicycle"
            });
            foreach (var e in _transportations) {
                Console.WriteLine("INSERT INTO Transportations VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                    e.Id, e.Manufacturer,e.NrOfPassengers,e.NrOfDoors,e.FuelTankCapacity,e.SaddleHeight,e.Type);
            }
        }
        [TestMethod]
        public void TransportationsTableTest()
        {
            var data = TransportationsTable();
            Console.WriteLine("SELECT * from Transportations");
            Assert.AreEqual(4,data.Count);
            Assert.AreEqual("Scott",data[1].Manufacturer);
            Assert.AreEqual(null, data[3].NrOfDoors);
        }
        [TestMethod]
        public void BicycleTableTest()
        {
            var data = BicycleDataTable();
            Console.WriteLine("SELECT * from Bicycle");
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("5.2 cm", data[0].SaddleHeight);
            Assert.AreEqual("1", data[0].NrOfPassengers);
        }
        [TestMethod]
        public void CarTableTest()
        {
            var data = CarDataTable();
            Console.WriteLine("SELECT * from Car");
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("Audi", data[1].Manufacturer);
            Assert.AreEqual("5", data[1].NrOfDoors);
        }

        private List<Transportations> TransportationsTable() {
            return _transportations;
        }

        private List<Car> CarDataTable() {
            Console.WriteLine("CREATE TABLE Car" +
                              "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                              " NrOfDoors TEXT, FuelTankCapacity TEXT");
            var data = TransportationsTable();
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

        private List<Bicycle> BicycleDataTable() {
            Console.WriteLine("CREATE TABLE Bicycle" +
                              "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                              " SaddleHeight TEXT");
            var data = TransportationsTable();
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
