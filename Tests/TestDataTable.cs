using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ül5;

namespace Tests {
    [TestClass]
    public class TestDataTable {
        private VehiclesMapper _vehiclesMapper;
        private BicycleMapper _bicycleMapper;
        private CarMapper _carMapper;
        private DataTable db;
        private List<Vehicles> _vehicles;

        [TestInitialize]
        public void Setup() {
            db = new DataTable("Vehicles");
            db.Clear();
            db.Columns.Add("ID", typeof(string));
            db.Columns.Add("Manufacturer", typeof(string));
            db.Columns.Add("NrOfPassengers", typeof(string));
            db.Columns.Add("NrOfDoors", typeof(string));
            db.Columns.Add("FuelTankCapacity", typeof(string));
            db.Columns.Add("SaddleHeight", typeof(string));
            db.Columns.Add("Type", typeof(string));
            db.Rows.Add("0", "Ford", "4", "5", "5l", null, "Car");
            db.Rows.Add("1", "Scott", "1", null, null, "5.2cm", "Bicycle");
            db.Rows.Add("2", "Audi", "4", "5", "4l", null, "Car");
            db.Rows.Add("3", "Merida", "1", null, null, "5.5cm", "Bicycle");
            getVehicles();
        }

        [TestMethod]
        public void VehiclesMapperTest() {
            var data = Vehicles();
            var findByIdData = _vehiclesMapper.findById("3", db);

            Assert.AreEqual(4, data.Count);
            Assert.AreEqual("3", findByIdData.Id);
            Assert.AreEqual("Merida", findByIdData.Manufacturer);
        }

        private void getVehicles() {
            _vehiclesMapper = new VehiclesMapper();
            _vehicles = _vehiclesMapper.GetVehicles(db);
        }

        private List<Vehicles> Vehicles() {
            return _vehicles;
        }

        [TestMethod]
        public void BicycleMapperTest() {
            _bicycleMapper = new BicycleMapper();
            var data = _bicycleMapper.GetBicycles(Vehicles());
            var findBicycleById = _bicycleMapper.findById("1", data);

            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("1", findBicycleById.Id);
            Assert.AreEqual("Scott", findBicycleById.Manufacturer);


        }

        [TestMethod]
        public void CarMapperTest() {
            _carMapper = new CarMapper();
            var data = _carMapper.GetCars(Vehicles());
            var findCarById = _carMapper.findById("2", data);

            Assert.AreEqual(2, data.Count);
            Assert.AreEqual("2", findCarById.Id);
            Assert.AreEqual("Audi", findCarById.Manufacturer);
            Assert.AreEqual("4l", findCarById.FuelTankCapacity);

            db.Rows.Add("4", "BMW", "7", "5", "100l", null, "Car");
            getVehicles();
            var newData = _carMapper.GetCars(Vehicles());
            var findCar2ById = _carMapper.findById("4", newData);

            Assert.AreEqual(3, newData.Count);
            Assert.AreEqual("BMW", findCar2ById.Manufacturer);
        }
    }
}
