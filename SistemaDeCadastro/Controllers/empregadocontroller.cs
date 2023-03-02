using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Interfaces;
using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Controllers

    {
    [Route("api/[controller/")]
    [ApiController]
    public class empregadocontroller : Controller
    {


        private readonly IEmpregadoRepositorio _empregadoRepositorio;

        public empregadocontroller (IEmpregadoRepositorio empregadoRepositorio)
        {
            _empregadoRepositorio = empregadoRepositorio;
        }

        [HttpGet]
        public async  Task<ActionResult<List<EmpregadoModel>>> BuscarTodosEmpregados()
        
        {
            List<EmpregadoModel> empregado = await _empregadoRepositorio.BuscarTodosEmpregados();
            return Ok(empregado);

        }

        [HttpGet]
        public async Task<ActionResult<EmpregadoModel>> BuscarPorId(int id)

        {
            EmpregadoModel  empregado = await _empregadoRepositorio.BuscarPorId(id);
            return Ok(empregado);

        }

        [HttpPost]

        public async Task<ActionResult<EmpregadoModel>> Cadastrar([FromBody] EmpregadoModel empregadoModel)
        {
           EmpregadoModel empregado = await _empregadoRepositorio.Adicionar(empregadoModel);

            return Ok(empregado);
        }






    }
       
    
}
