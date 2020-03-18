using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [Route("equation")]
    [ApiController]
    public class EquationController : ControllerBase
    {
        [HttpGet]
        public string Result(int a, int b, int c)
        {
            //D
            int D;
            double x1;
            double x2;

            D = b * b - 4 * a * c;

            if (D == 0)
            {
                x1 = (-b + Math.Sqrt(D)) / 2 * a;
                return x1.ToString();
            }

            if (D > 0)
            {
                x1 = (-b + -(Math.Sqrt(D))) / 2 * a;
                x2 = (-b + Math.Sqrt(D)) / 2 * a;
                return x1.ToString() + " " + x2.ToString();
            }

            else
            {
                return "нет корней";
            }
        }

    }
}