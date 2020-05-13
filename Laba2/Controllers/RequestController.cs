using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModels;
using LinqToDB;
using Laba2.DataModels;

namespace Laba2.Controllers
{
    [Route("requests")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [HttpGet("read")]
        public IEnumerable<Request> Read()
        {
            return MyServiceModel.Requests;
        }

        [HttpGet("create")]
        //requests/create?client_id=2&service_id=1
        public string Create(int client_id, int service_id)
        {
            MyServiceModel.Context.Insert(new Request
            {
                ClientId = client_id,
                ServiceId = service_id
            });
            return "Создана запись: client_id=" + client_id + "; service_id=" + service_id;
        }

        [HttpGet("update")]
        //requests/update?id=1&client_id=1&service_id=1
        public string Update(int id, int client_id, int service_id)
        {
            var record = MyServiceModel.Requests.FirstOrDefault(a => a.Id == id);
            if (record is null) return "Несуществующий ID";
            {
                record.ClientId = client_id; record.ServiceId = service_id;
                MyServiceModel.MyserviceDB.Update(record);
            }

            return "Запись с id=" + id + " изменена на client_id=" + client_id + "; service_id=" + service_id;
        }
        [HttpGet("delete")]
        //requests/delete?id=1
        public string Delete(int id)
        {
            var record = MyServiceModel.Requests.FirstOrDefault(a => a.Id == id);
            if (record is null) return "Несуществующий ID";
            MyServiceModel.MyserviceDB.Delete(record);
            return "Запись с id=" + id + " удалена.";
        }

    }
}
