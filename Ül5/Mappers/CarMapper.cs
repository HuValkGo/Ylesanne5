using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ül5 {
    public class CarMapper {
        public List<Car> GetCars(List<Vehicles> data) {
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
    }
}
