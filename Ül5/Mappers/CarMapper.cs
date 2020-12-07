using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ül5 {
    public class CarMapper {
        public List<Car> GetCars(List<Vechicles> data) {
            List<Car> cars = new List<Car>();
            foreach (var d in data) {
                if (d.Type == "Car") {
                    cars.Add(new Car() {
                        Id = d.Id,
                        Manufacturer = d.Manufacturer,
                        NrOfPassengers = d.NrOfPassengers,
                        NrOfDoors = d.NrOfDoors,
                        FuelTankCapacity = d.FuelTankCapacity
                    });
                }
            }

            return cars;
        }

        public Car findById(string id, List<Car> data) {
            Car car = new Car();
            foreach (var e in data) {
                if (id == e.Id) {
                    car.Id = e.Id;
                    car.Manufacturer = e.Manufacturer;
                    car.NrOfPassengers = e.NrOfPassengers;
                    car.NrOfDoors = e.NrOfDoors;
                    car.FuelTankCapacity = e.FuelTankCapacity;
                    break;
                }
            }

            return car;
        }
    }
}
