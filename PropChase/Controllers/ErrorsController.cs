using Microsoft.AspNetCore.Mvc;

namespace PropChase.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}