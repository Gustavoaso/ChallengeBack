using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace SistemaDeCadastro.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class empregadocontroller : Controller
    {


        private readonly IEmpregadoRepositorio _empregadoRepositorio;

        public empregadocontroller(IEmpregadoRepositorio empregadoRepositorio)
        {
            _empregadoRepositorio = empregadoRepositorio;
        }
      
        [HttpGet]
        public async Task<ActionResult<List<EmpregadoModel>>> BuscarTodosEmpregados()

        {
            List<EmpregadoModel> empregado = await _empregadoRepositorio.BuscarTodosEmpregados();
            return Ok(empregado);

        }
   
        [HttpGet("{id}") ]
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
        
        [HttpPut("{id}")]
        public async Task<ActionResult<EmpregadoModel>> Atualizar([FromBody] EmpregadoModel empregadoModel, int id)
        {
            empregadoModel.IdEmpregado = id;
            EmpregadoModel empregado = await _empregadoRepositorio.Atualizar(empregadoModel,id);

            return Ok(empregado);
        }
     
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpregadoModel>> Apagar( int id)
        {
           
           bool apagado = await _empregadoRepositorio.Apagar(id);

            return Ok(apagado);
        }







    }
       
    
}
