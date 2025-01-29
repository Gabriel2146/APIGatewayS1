using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        // Aquí se pueden definir endpoints para realizar solicitudes
        // a otros microservicios si es necesario

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Transaction Service Gateway");
        }
    }
}
