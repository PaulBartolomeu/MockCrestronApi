using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MockCrestronApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrestronNVX : ControllerBase
    {

        private readonly ILogger<CrestronNVX> _logger;

        public CrestronNVX(ILogger<CrestronNVX> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "CrestronNVX")]
        public object Get(string? ip, string? name, string? password)
        {
            var headers = Request.Headers;
            if (headers.ContainsKey("TRACKID"))
            {
                var trackId = headers["TRACKID"];
                if(string.IsNullOrEmpty(trackId) || trackId != "weoiruqpwe14214312342143")
                {
                    var err = new { error = "Authentication failed" };
                    Response.StatusCode = 500;
                    return err;
                }
            }
            if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                var err = new { error = "authentication failed" };
                Response.StatusCode = 500;
                return err;
            }
            else if(!new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b").Match(ip).Success)
            {
                var err = new { error = "Invalid IP:" + ip };
                Response.StatusCode = 500;
                return err;
            }
            else
            {
                var random = new Random();
                var DMNVX = new
                {
                    HorizontalResolution = 1920,
                    IsInterlacedDetected = false,
                    IsSourceDetected = false,
                    IsSyncDetected = random.Next(2) == 1,
                    PortType = "HDMI",
                    Uuid = "ee665f83-58cf-4f16-b2ae-6dcea693b060",
                    VerticalResolution = 1080
                };
                return DMNVX;
            }
        }


    }
}
