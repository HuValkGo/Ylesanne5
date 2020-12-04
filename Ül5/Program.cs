
namespace Ül5 {
    class Program {
        static void Main(string[] args) {
            VechiclesController d = new VechiclesController();
            d.AddData();
            d.GetVechiclesTable();
            d.GetBicycleTable();
            d.GetCarTable();
        }
    }
}
