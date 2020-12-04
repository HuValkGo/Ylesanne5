using System;
using System.Collections.Generic;

namespace Ül5 {
    public class DataController {

        private List<Data> _dataTable;

        public void AddData() {
            _dataTable= new List<Data>();
            _dataTable.Add(new Data() {
                Id = "0",
                FuelTankCapacity = "5l",
                NrOfPassengers = "5",
                Manufacturer = "Ford",
                NrOfDoors = "5",
                Type = "Car"
            });
            _dataTable.Add(new Data() {
                Id = "1",
                Manufacturer = "Scott",
                NrOfPassengers = "1",
                SaddleHeight = "5.2 cm",
                Type = "Bicycle"
            });
            _dataTable.Add(new Data() {
                Id = "2",
                FuelTankCapacity = "4l",
                NrOfPassengers = "5",
                Manufacturer = "Audi",
                NrOfDoors = "5",
                Type = "Car"
            });
            _dataTable.Add(new Data() {
                Id = "3",
                Manufacturer = "Merida",
                NrOfPassengers = "1",
                SaddleHeight = "5.5 cm",
                Type = "Bicycle"
            });

        }

        private List<Data> DataTable() {
            return _dataTable;
        }

        private List<Car> CarDataTable() {
            var data = DataTable();
            List<Car> cars = new List<Car>();
            foreach (var d in data) {
                if (d.Type == "Car") {
                    cars.Add(new Car() {
                        Id = d.Id,
                        FuelTankCapacity = d.FuelTankCapacity,
                        NrOfPassengers = d.NrOfPassengers,
                        Manufacturer = d.Manufacturer,
                        NrOfDoors = d.NrOfDoors
                    });
                }
            }

            return cars;
        }

        private List<Bicycle> BicycleDataTable() {
            var data = DataTable();
            List<Bicycle> bicycles = new List<Bicycle>();
            foreach (var d in data) {
                if (d.Type == "Bicycle") {
                    bicycles.Add(new Bicycle() {
                        Id = d.Id,
                        SaddleHeight = d.SaddleHeight,
                        NrOfPassengers = d.NrOfPassengers,
                        Manufacturer = d.Manufacturer
                    });
                }
            }

            return bicycles;
        }

        public void GetBicycleDataTable() {
            foreach (var d in BicycleDataTable()) {
                Console.Write(" Id: " + d.Id +
                              " NrOfPassengers: " + d.NrOfPassengers +
                              " Manufacturer: " + d.Manufacturer +
                              " SaddleHeight: " + d.SaddleHeight);
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void GetDataTable() {
            foreach (var a in DataTable()) {
                Console.Write(" Id: " + a.Id +
                              " NrOfPassengers: " + a.NrOfPassengers +
                              " Manufacturer: " + a.Manufacturer +
                              " FuelTankCapacity: " + a.FuelTankCapacity +
                              " NrOfDoors: " + a.NrOfDoors +
                              " SaddleHeight: " + a.SaddleHeight +
                              " Type: " + a.Type);
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void GetCarDataTable() {
            foreach (var a in CarDataTable()) {
                Console.Write(" Id: " + a.Id +
                              " NrOfPassengers: " + a.NrOfPassengers +
                              " Manufacturer: " + a.Manufacturer +
                              " FuelTankCapacity: " + a.FuelTankCapacity +
                              " NrOfDoors: " + a.NrOfDoors);
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
