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
        private List<Data> _dataTable;
        [TestInitialize]
        public void Setup() {
            Console.WriteLine("CREATE TABLE Data" +
                          "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                          "NrOfDoors TEXT, FuelTankCapacity TEXT, SaddleHeight TEXT, Type TEXT");
            _dataTable = new List<Data>();
            _dataTable.Add(new Data() {
                Id = "0",
                Manufacturer = "Ford",
                NrOfPassengers = "5",
                NrOfDoors = "5",
                FuelTankCapacity = "5l",
                SaddleHeight = null,
                Type = "Auto"
            });
            _dataTable.Add(new Data()
            {
                Id = "1",
                Manufacturer = "Scott",
                NrOfPassengers = "1",
                NrOfDoors = null,
                FuelTankCapacity = null,
                SaddleHeight = "5.2 cm",
                Type = "Jalgratas"
            });
            _dataTable.Add(new Data()
            {
                Id = "2",
                Manufacturer = "Audi",
                NrOfPassengers = "5",
                NrOfDoors = "5",
                FuelTankCapacity = "4l",
                SaddleHeight = null,
                Type = "Auto"
            });
            _dataTable.Add(new Data()
            {
                Id = "3",
                Manufacturer = "Merida",
                NrOfPassengers = "1",
                NrOfDoors = null,
                FuelTankCapacity = null,
                SaddleHeight = "5.5 cm",
                Type = "Jalgratas"
            });
            foreach (var e in _dataTable) {
                Console.WriteLine("INSERT INTO Data VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                    e.Id, e.Manufacturer,e.NrOfPassengers,e.NrOfDoors,e.FuelTankCapacity,e.SaddleHeight,e.Type);
            }
        }
        [TestMethod]
        public void DataTableTest()
        {
            var data = DataTable();
            Console.WriteLine("SELECT * from Data");
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

        private List<Data> DataTable() {
            return _dataTable;
        }

        private List<Car> CarDataTable() {
            Console.WriteLine("CREATE TABLE Car" +
                              "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                              " NrOfDoors TEXT, FuelTankCapacity TEXT");
            var data = DataTable();
            List<Car> cars = new List<Car>();
            foreach (var d in data)
            {
                if (d.Type == "Auto")
                {
                    cars.Add(new Car()
                    {
                        Id = d.Id,
                        Manufacturer = d.Manufacturer,
                        NrOfPassengers = d.NrOfPassengers,
                        NrOfDoors = d.NrOfDoors,
                        FuelTankCapacity = d.FuelTankCapacity
                    });
                    Console.WriteLine("INSERT INTO Data VALUES ({0}, {1}, {2}, {3}, {4})",
                        d.Id, d.Manufacturer, d.NrOfPassengers, d.NrOfDoors, d.FuelTankCapacity);
                }
            }
            return cars;
        }

        private List<Bicycle> BicycleDataTable() {
            Console.WriteLine("CREATE TABLE Bicycle" +
                              "(Id TEXT PRIMARY KEY, Manufacturer TEXT, NrOfPassengers TEXT," +
                              " SaddleHeight TEXT");
            var data = DataTable();
            List<Bicycle> bicycles = new List<Bicycle>();
            foreach (var d in data)
            {
                if (d.Type == "Jalgratas")
                {
                    bicycles.Add(new Bicycle()
                    {
                        Id = d.Id,
                        Manufacturer = d.Manufacturer,
                        NrOfPassengers = d.NrOfPassengers,
                        SaddleHeight = d.SaddleHeight
                    });
                    Console.WriteLine("INSERT INTO Data VALUES ({0}, {1}, {2}, {3})",
                        d.Id, d.Manufacturer, d.NrOfPassengers, d.SaddleHeight);
                }
            }

            return bicycles;
        }
    }
}
