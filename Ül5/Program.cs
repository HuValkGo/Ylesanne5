
namespace Ül5 {
    class Program {
        static void Main(string[] args) {
            TransportationsController d = new TransportationsController();
            d.AddData();
            d.GetTransportationsTable();
            d.GetBicycleDataTable();
            d.GetCarDataTable();
        }
    }
}
