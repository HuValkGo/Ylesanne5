using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ül5 {
    public class VechiclesMapper {
        public List<Vechicles> GetVechicles(DataTable db) {
            List<Vechicles> vechicles = new List<Vechicles>();
            for (int i = 0; i < db.Rows.Count; i++) {

                var obj = db.Rows[i].ItemArray;
                vechicles.Add(new Vechicles() {
                    Id = obj[0].ToString(),
                    Manufacturer = obj[1].ToString(),
                    NrOfPassengers = obj[2].ToString(),
                    NrOfDoors = obj[3].ToString(),
                    FuelTankCapacity = obj[4].ToString(),
                    SaddleHeight = obj[5].ToString(),
                    Type = obj[6].ToString()
                });
            }

            return vechicles;
        }

        public Vechicles findById(string id, DataTable db) {
            Vechicles vechicle = new Vechicles();
            for (int i = 0; i < db.Rows.Count; i++) {
                var obj = db.Rows[i].ItemArray;
                if (id == obj[0].ToString()) {
                    vechicle.Id = obj[0].ToString();
                    vechicle.Manufacturer = obj[1].ToString();
                    vechicle.NrOfPassengers = obj[2].ToString();
                    vechicle.NrOfDoors = obj[3].ToString();
                    vechicle.FuelTankCapacity = obj[4].ToString();
                    vechicle.SaddleHeight = obj[5].ToString();
                    vechicle.Type = obj[6].ToString();
                    break;
                }
            }

            return vechicle;
        }
    }
}
