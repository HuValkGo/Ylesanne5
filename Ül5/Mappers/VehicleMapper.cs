using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ül5 {
    public class VehicleMapper {
        public List<Vehicles> GetVehicles(DataTable db) {
            List<Vehicles> vehicles = new List<Vehicles>();
            for (int i = 0; i < db.Rows.Count; i++) {
                var obj = db.Rows[i].ItemArray;
                vehicles.Add(new Vehicles() {
                    Id = obj[0].ToString(),
                    Manufacturer = obj[1].ToString(),
                    NrOfPassengers = obj[2].ToString(),
                    NrOfDoors = obj[3].ToString(),
                    FuelTankCapacity = obj[4].ToString(),
                    SaddleHeight = obj[5].ToString(),
                    Type = obj[6].ToString()
                });
            }

            return vehicles;
        }

        public Vehicle findById(string id, DataTable db) {
            var vehicle = new Vehicle();
            for (int i = 0; i < db.Rows.Count; i++) {
                var obj = db.Rows[i].ItemArray;
                var type = obj[6].ToString();
                if (id == obj[0].ToString()) {
                    if (type == "Car") {
                        vehicle = new Car() {
                            Id = obj[0].ToString(),
                            Manufacturer = obj[1].ToString(),
                            NrOfPassengers = obj[2].ToString(),
                            NrOfDoors = obj[3].ToString(),
                            FuelTankCapacity = obj[4].ToString()
                        };
                        break;
                    }

                    if (type == "Bicycle") {
                        vehicle = new Bicycle() {
                            Id = obj[0].ToString(),
                            Manufacturer = obj[1].ToString(),
                            NrOfPassengers = obj[2].ToString(),
                            SaddleHeight = obj[5].ToString()
                        };
                        break;
                    }
                }
            }
            return vehicle;
        }
    }
}
