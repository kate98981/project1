using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [Route("weekday/date")]
    [ApiController]
    public class WeekdayController : ControllerBase
    {
        //weekday/date/12.12.2028
        [HttpGet("{dt}")]
        public string WeekDay(string dt)
        {
            string[] date = dt.Split(new char[] { '.' });
            DateTime Dt = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
            return Dt.ToString("dddd");
            
        }

    }
}