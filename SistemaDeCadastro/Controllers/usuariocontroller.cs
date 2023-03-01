using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Controllers

    {
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : Controller
    {
        [HttpGet]
        public ActionResult<List<EmpregadoModel>> BuscarTodosEmpregados()
        
        
        {
            return Ok();

        }




    }
       
    
}
