using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ül5;

namespace Tests {
    [TestClass]
    public class TestDataTable {
        private VehicleMapper _vehicleMapper;
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
            Assert.AreEqual(4, data.Count);

            var findByIdData = _vehicleMapper.findById("3", db);
            Bicycle bicycle = (Bicycle) findByIdData;

            Assert.AreEqual("3", bicycle.Id);
            Assert.AreEqual("Merida", bicycle.Manufacturer);
            Assert.AreEqual("5.5cm",bicycle.SaddleHeight);

            db.Rows.Add("4", "BMW", "7", "5", "100l", null, "Car");
            getVehicles();
            var newData = _vehicleMapper.GetVehicles(db);
            var findById2 = _vehicleMapper.findById("4", db);
            Car car = (Car)findById2;

            Assert.AreEqual(5, newData.Count);
            Assert.AreEqual("BMW", car.Manufacturer);
            Assert.AreEqual("100l", car.FuelTankCapacity);

        }

        private void getVehicles() {
            _vehicleMapper = new VehicleMapper();
            _vehicles = _vehicleMapper.GetVehicles(db);
        }

        private List<Vehicles> Vehicles() {
            return _vehicles;
        }

        [TestMethod]
        public void BicycleMapperTest() {
            _bicycleMapper = new BicycleMapper();
            var data = _bicycleMapper.GetBicycles(Vehicles());

            Assert.AreEqual(2, data.Count);
        }

        [TestMethod]
        public void CarMapperTest() {
            _carMapper = new CarMapper();
            var data = _carMapper.GetCars(Vehicles());

            Assert.AreEqual(2, data.Count);

            db.Rows.Add("4", "BMW", "7", "5", "100l", null, "Car");
            getVehicles();
            var newData = _carMapper.GetCars(Vehicles());

            Assert.AreEqual(3, newData.Count);
        }
    }
}
