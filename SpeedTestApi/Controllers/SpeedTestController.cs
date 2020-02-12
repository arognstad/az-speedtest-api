using Microsoft.AspNetCore.Mvc;

namespace SpeedTestApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SpeedTestController : ControllerBase
  {
    // GET speedtest/ping
    [Route("ping")]
    [HttpGet]
    public string Ping()
    {
      return "PONG";
    }
  }
}