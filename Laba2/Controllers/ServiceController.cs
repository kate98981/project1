using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModels;
using LinqToDB;
using Laba2.DataModels;


namespace Laba2.Controllers
{
    [Route("services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet("read")]
        public IEnumerable<Service> Read()
        {
            return MyServiceModel.Services;
        }

        [HttpGet("create")]
        //services/create?name=Чистка клавиатуры&price=1000
        public string Create(string name, string price)
        {
            MyServiceModel.Context.Insert(new Service
            {
                Name = name, Price = price
            });
            return "Создана запись: name=" + name + "; price=" + price;
        }
        [HttpGet("update")]
        //services/update?id=1&name=Настройка компьютера&price=2111-5111
        public string Update(int id, string name, string price)
        {
            var record = MyServiceModel.Services.FirstOrDefault(a => a.Id == id);
            if (record is null) return "Несуществующий ID";
            {
              record.Name = name; record.Price = price;
              MyServiceModel.MyserviceDB.Update(record);
            }

            return "Запись с id=" + id + " изменена на name=" + name + "; price="+price;
        }
        [HttpGet("delete")]
        //services//delete?id=1
        public string Delete(int id)
        {
            var record = MyServiceModel.Services.FirstOrDefault(a => a.Id == id);
            if (record is null) return "Несуществующий ID";
            MyServiceModel.MyserviceDB.Delete(record);
            return "Запись с id="+id+" удалена.";
        }

    }
}
