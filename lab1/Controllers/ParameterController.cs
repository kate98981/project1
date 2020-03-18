using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    //Прописью возвращать значение числа, заданного в URL в качестве параметра пути
    [Route("parameter")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        [HttpGet("{num}")]
        public string Get(int num)
        {
            return num.ToString();
        }
    }

}