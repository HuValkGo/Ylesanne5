using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ül5 {
    public class VehiclesMapper {
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

        public Vehicles findById(string id, DataTable db) {
            Vehicles vehicle = new Vehicles();
            for (int i = 0; i < db.Rows.Count; i++) {
                var obj = db.Rows[i].ItemArray;
                if (id == obj[0].ToString()) {
                    vehicle.Id = obj[0].ToString();
                    vehicle.Manufacturer = obj[1].ToString();
                    vehicle.NrOfPassengers = obj[2].ToString();
                    vehicle.NrOfDoors = obj[3].ToString();
                    vehicle.FuelTankCapacity = obj[4].ToString();
                    vehicle.SaddleHeight = obj[5].ToString();
                    vehicle.Type = obj[6].ToString();
                    break;
                }
            }

            return vehicle;
        }
    }
}
