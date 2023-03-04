using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace SistemaDeCadastro.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : Controller
    {


        private readonly IProjetoRepositorio _projetoRepositorio;

        public ProjetoController(IProjetoRepositorio projetoRepositorio)
        {
            _projetoRepositorio = projetoRepositorio;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<ProjetoModel>>> BuscaTodosProjetos()

        {
            List<ProjetoModel> projeto = await _projetoRepositorio.BuscarTodosProjetos();
            return Ok(projeto);

        }
     
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjetoModel>> BuscarPorId(int id)

        {
            ProjetoModel projeto = await _projetoRepositorio.BuscarPorId(id);
            return Ok(projeto);

        }
     
        [HttpPost]

        public async Task<ActionResult<ProjetoModel>> Cadastrar([FromBody] ProjetoModel projetoModel)
        {

            ProjetoModel projeto = await _projetoRepositorio.Adicionar(projetoModel);

            return Ok(projeto);
        }
  
        [HttpPut("{id}")]
        public async Task<ActionResult<ProjetoModel>> Atualizar([FromBody] ProjetoModel projetoModel, int id)
        {
            projetoModel.IdProjeto = id;
            ProjetoModel projeto = await _projetoRepositorio.Atualizar(projetoModel, id);

            return Ok(projeto);
        }
   
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpregadoModel>> Apagar(int id)
        {

            bool apagado = await _projetoRepositorio.Apagar(id);

            return Ok(apagado);
        }







    }


}
