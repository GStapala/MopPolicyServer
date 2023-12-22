using Microsoft.AspNetCore.Mvc;

namespace WebApiNswagTest.Controllers;

public class TestController : Controller
{
    [HttpGet]
    [Route("Test")]
    public string TestGet()
    {
        return "Test";
    }
}
