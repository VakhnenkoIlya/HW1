using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LessonWeb1.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    //HW1
    public class CrudController : ControllerBase
    {
        private static List<WeatherForecast> _data = new List<WeatherForecast>();
        [HttpPost("create")]
        public IActionResult Create([FromQuery] int temp, [FromQuery] DateTime date)
        {
            _data.Add(new WeatherForecast() { TemperatureC = temp, Date = date });
            return Ok();
        }

        [HttpGet("read")]
        public List<WeatherForecast> Read()
        {
            return _data;
        }
        [HttpPut("update")]
        public IActionResult Update([FromQuery] int newTemp, [FromQuery] DateTime date)
        {
            foreach(var element in _data)
            {
                if (element.Date == date)
                {
                    element.TemperatureC = newTemp;
                    break;
                }
            }
            return Ok();
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime start, [FromQuery]DateTime end)
        {
            int quantity = 0;
            int index = -1;
            for(int i = 0; i<_data.Count; i++)
            {
                if (_data[i].Date >= start && _data[i].Date <= end)
                {
                    if (index == -1) index = i;
                    quantity++;
                }
            }
            return Ok();
        }

     
    }
}
