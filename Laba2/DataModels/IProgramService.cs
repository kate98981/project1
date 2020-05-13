using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using DataModels;

namespace Laba2.DataModels
{
    [ServiceContract]
    public interface IProgramService
    {
        [OperationContract]
        IEnumerable<Client> ReadClients();
        [OperationContract]
        IEnumerable<Service> ReadServices();
        [OperationContract]
        IEnumerable<Request> ReadRequest();

        [OperationContract]
        IEnumerable<Client> CreateClient(Client client);
        [OperationContract]
        IEnumerable<Service> CreateService(Service service);
        [OperationContract]
        IEnumerable<Request> CreateRequest(Request request);

        [OperationContract]
        IEnumerable<Client> UpdateClient(Client client);
        [OperationContract]
        IEnumerable<Service> UpdateService(Service service);
        [OperationContract]
        IEnumerable<Request> UpdateRequest(Request request);

        [OperationContract]
        IEnumerable<Client> DeleteClient(Client client);
        [OperationContract]
        IEnumerable<Service> DeleteService(Service service);
        [OperationContract]
        IEnumerable<Request> DeleteRequest(Request request);
    }
}
