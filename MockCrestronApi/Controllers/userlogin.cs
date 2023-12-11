using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockCrestronApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class userlogin : ControllerBase
    {
        // GET: api/<userlogin>
        [HttpGet(Name = "userlogin")]
        public object Get(string? name, string? password)
        {

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                var err = new { error = "Authentication failed" };
                Response.StatusCode = 500;
                return err;
            }
            return new { TRACKID = "weoiruqpwe14214312342143" };
        }
    }
}
