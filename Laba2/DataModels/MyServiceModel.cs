using System.Runtime.Serialization;
using DataModels;
using LinqToDB;

namespace Laba2.DataModels
{
    [DataContract]
    public class MyServiceModel
    {
        public static MyserviceDB MyserviceDB { get; } = new MyserviceDB();
        public static DataContext Context { get; } = new DataContext();

        public static ITable<Client> Clients { get; } = MyserviceDB.GetTable<Client>();
        public static ITable<Service> Services { get; } = MyserviceDB.GetTable<Service>();
        public static ITable<Request> Requests { get; } = MyserviceDB.GetTable<Request>().LoadWith(a => a.Client).LoadWith(a => a.Service);
    }
}
