using System;
using System.Collections.Generic;

namespace Ül5 {
    public class VechiclesController {

        private List<Vechicles> _vechicles;

        public void AddData() {
            _vechicles = new List<Vechicles>();
            _vechicles.Add(new Vechicles() {
                Id = "0",
                FuelTankCapacity = "5l",
                NrOfPassengers = "5",
                Manufacturer = "Ford",
                NrOfDoors = "5",
                Type = "Car"
            });
            _vechicles.Add(new Vechicles() {
                Id = "1",
                Manufacturer = "Scott",
                NrOfPassengers = "1",
                SaddleHeight = "5.2 cm",
                Type = "Bicycle"
            });
            _vechicles.Add(new Vechicles() {
                Id = "2",
                FuelTankCapacity = "4l",
                NrOfPassengers = "5",
                Manufacturer = "Audi",
                NrOfDoors = "5",
                Type = "Car"
            });
            _vechicles.Add(new Vechicles() {
                Id = "3",
                Manufacturer = "Merida",
                NrOfPassengers = "1",
                SaddleHeight = "5.5 cm",
                Type = "Bicycle"
            });

        }

        private List<Vechicles> VechiclesTable() {
            return _vechicles;
        }

        private List<Car> CarTable() {
            var data = VechiclesTable();
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

        private List<Bicycle> BicycleTable() {
            var data = VechiclesTable();
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

        public void GetBicycleTable() {
            foreach (var d in BicycleTable()) {
                Console.Write(" Id: " + d.Id +
                              " NrOfPassengers: " + d.NrOfPassengers +
                              " Manufacturer: " + d.Manufacturer +
                              " SaddleHeight: " + d.SaddleHeight);
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void GetVechiclesTable() {
            foreach (var a in VechiclesTable()) {
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

        public void GetCarTable() {
            foreach (var a in CarTable()) {
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
