
namespace Ül5 {
    class Program {
        static void Main(string[] args) {
            DataController d = new DataController();
            d.AddData();
            d.GetDataTable();
            d.GetBicycleDataTable();
            d.GetCarDataTable();
        }
    }
}
