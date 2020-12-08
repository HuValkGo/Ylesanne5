
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Ül5 {
    class Program {
        static void Main(string[] args) {
            Program p = new Program();
            p.Setup();
        }
        public DataTable Setup()
        {
            DataTable db = new DataTable("Vehicles");
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
            return db;
        }
    }
}
