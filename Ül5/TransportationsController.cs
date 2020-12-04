using System;
using System.Collections.Generic;
using System.Text;

namespace Ül5 {
    public class TransportationsController {

        private List<Transportations> _transportations;

        public void AddData() {
            _transportations= new List<Transportations>();
            _transportations.Add(new Transportations() {
                Id = "0",
                FuelTankCapacity = "5l",
                NrOfPassengers = "5",
                Manufacturer = "Ford",
                NrOfDoors = "5",
                Type = "Car"
            });
            _transportations.Add(new Transportations() {
                Id = "1",
                Manufacturer = "Scott",
                NrOfPassengers = "1",
                SaddleHeight = "5.2 cm",
                Type = "Bicycle"
            });
            _transportations.Add(new Transportations() {
                Id = "2",
                FuelTankCapacity = "4l",
                NrOfPassengers = "5",
                Manufacturer = "Audi",
                NrOfDoors = "5",
                Type = "Car"
            });
            _transportations.Add(new Transportations() {
                Id = "3",
                Manufacturer = "Merida",
                NrOfPassengers = "1",
                SaddleHeight = "5.5 cm",
                Type = "Bicycle"
            });

        }

        private List<Transportations> TransportationsTable() {
            return _transportations;
        }

        private List<Car> CarDataTable() {
            var data = TransportationsTable();
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
            var data = TransportationsTable();
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

        public void GetTransportationsTable() {
            foreach (var a in TransportationsTable()) {
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
