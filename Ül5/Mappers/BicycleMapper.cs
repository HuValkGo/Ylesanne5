using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ül5 {
    public class BicycleMapper {
        public List<Bicycle> GetBicycles(List<Vehicles> data) {
            List<Bicycle> bicycles = new List<Bicycle>();
            foreach (var d in data) {
                if (d.Type == "Bicycle") {
                    bicycles.Add(new Bicycle() {
                        Id = d.Id,
                        Manufacturer = d.Manufacturer,
                        NrOfPassengers = d.NrOfPassengers,
                        SaddleHeight = d.SaddleHeight
                    });
                }
            }

            return bicycles;
        }

        public Bicycle findById(string id, List<Bicycle> data) {
            Bicycle bicycle = new Bicycle();
            foreach (var e in data) {
                if (id == e.Id) {
                    bicycle.Id = e.Id;
                    bicycle.Manufacturer = e.Manufacturer;
                    bicycle.NrOfPassengers = e.NrOfPassengers;
                    bicycle.SaddleHeight = e.SaddleHeight;
                    break;
                }
            }

            return bicycle;
        }
    }
}
