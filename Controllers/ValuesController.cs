using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apicore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("Get")]
        [HttpGet]
        public String GetName()
        {
            return "Test";
        }

         //[Route("Getfullname")]
        [HttpGet]
        public String Getfullname()
        {
            return "Test mitu";
        }
    }
}
