using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels;
using LinqToDB;

namespace Laba2.DataModels
{
    public class ProgramService : IProgramService
    {
        //read
        public IEnumerable<Client> ReadClients()
        {
           return MyServiceModel.Clients;
        }
        public IEnumerable<Service> ReadServices()
        {
            return MyServiceModel.Services;
        }
        public IEnumerable<Request> ReadRequest()
        {
            return MyServiceModel.Requests;
        }

        //create
        public IEnumerable<Client> CreateClient(Client client)
        {
            MyServiceModel.Context.Insert(client);
            return CreateClient(client);
        }
        public IEnumerable<Request> CreateRequest(Request request)
        {
            MyServiceModel.Context.Insert(request);
            return CreateRequest(request);
        }
        public IEnumerable<Service> CreateService(Service service)
        {
            MyServiceModel.Context.Insert(service);
            return CreateService(service);
        }

        //delete
        public IEnumerable<Client> DeleteClient(Client client)
        {
            MyServiceModel.Context.Delete(client);
            return DeleteClient(client);
        }
        public IEnumerable<Request> DeleteRequest(Request request)
        {
            MyServiceModel.Context.Delete(request);
            return DeleteRequest(request);
        }
        public IEnumerable<Service> DeleteService(Service service)
        {
            MyServiceModel.Context.Delete(service);
            return DeleteService(service);
        }

        //update
        public IEnumerable<Client> UpdateClient(Client client)
        {
            MyServiceModel.Context.Update(client);
            return UpdateClient(client);
        }
        public IEnumerable<Request> UpdateRequest(Request request)
        {
            MyServiceModel.Context.Update(request);
            return UpdateRequest(request);
        }
        public IEnumerable<Service> UpdateService(Service service)
        {
            MyServiceModel.Context.Delete(service);
            return UpdateService(service);
        }
        
    }
}
