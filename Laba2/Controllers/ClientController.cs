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
    [Route("clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        [HttpGet("read")]
        public IEnumerable<Client> Read() {
            return MyServiceModel.Clients;   
        }
        [HttpGet("create")]
        //clients/create?surname=Иванов&name=Иван&middleName=Иванович&phone=89011111111
        public string Create(string surname, string name, string middleName, string phone)
        {
            MyServiceModel.Context.Insert(new Client
            {
                Surname = surname,
                Name = name,
                MiddleName = middleName,
                Phone = phone
            });
            return "Создана запись: surname=" + surname + "; name=" + name + "; middleName=" + middleName + "; phone=" + phone;
        }

        [HttpGet("update")]
        //clients/update?id=1&surname=Иванов&name=Иван&middleName=Иванович&phone=22-22-22
        public string Update(int id, string surname, string name, string middleName, string phone)
        {
            var record = MyServiceModel.Clients.FirstOrDefault(a => a.Id == id);
            if (record is null) return "Несуществующий ID";
            record.Surname = surname; record.Name = name; record.MiddleName = middleName; record.Phone = phone;
            MyServiceModel.MyserviceDB.Update(record);
           
            return "Запись с id=" + id + " изменена на surname=" + surname + "; name=" + name + "; middleName=" + middleName + "; phone=" + phone;
        }
        [HttpGet("delete")]
        //clients/delete?id=1
        public string Delete(int id)
        {
            var record = MyServiceModel.Clients.FirstOrDefault(a => a.Id == id);
            if (record is null) return "Несуществующий ID";
            MyServiceModel.MyserviceDB.Delete(record);
            return "Запись с id=" + id + " удалена.";
        }
    }

}
