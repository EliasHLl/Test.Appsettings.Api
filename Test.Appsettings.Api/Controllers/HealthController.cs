using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Appsettings.Api.Controllers
{

    [Route("Health")]
    public class HealthController : ControllerBase
    {
        private readonly IHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        public HealthController(IHostEnvironment environment,IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }
        [HttpGet("[action]")]
        public IActionResult Status()
        {
            try
            {
                var data = _configuration.GetSection("Sample:datashow").Value;
                var generalData = _configuration.GetValue<string>("General");
                return Ok($"Ok=>{_environment.EnvironmentName}=>{data} | Parent Data: {generalData}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}
