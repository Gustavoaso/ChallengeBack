using SistemaDeCadastro.Data;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeCadastro.Repositorios
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {

        private readonly SistemaDeCadastroDBContext _dbContext;

        public ProjetoRepositorio(SistemaDeCadastroDBContext sistemaDeCadastroDBContext)
        {
            _dbContext = sistemaDeCadastroDBContext;
        }
        public async Task<ProjetoModel> BuscarPorId(int id)
        {
            return await _dbContext.projetos.Include(x=>x.Gerente).FirstOrDefaultAsync(x => x.IdProjeto == id);
        }

        public async Task<List<ProjetoModel>> BuscarTodosProjetos()
        {
            return await _dbContext.projetos.Include(x => x.Gerente).ToListAsync();
        }
        public async Task<ProjetoModel> Adicionar(ProjetoModel projeto)
        {
            await _dbContext.projetos.AddAsync(projeto);
            await _dbContext.SaveChangesAsync();
            return projeto;
        }

        public async Task<bool> Apagar(int id)
        {
            ProjetoModel ProjetoPorId = await BuscarPorId(id);

            if (ProjetoPorId == null)
            {
                throw new Exception($"Projeto do ID: {id} não foi encontrado");
            }
            else
            {
                _dbContext.projetos.Remove(ProjetoPorId);
                await _dbContext.SaveChangesAsync();

            }
            return true;
        }

        public async Task<ProjetoModel> Atualizar(ProjetoModel projeto, int id)
        {
            ProjetoModel ProjetoPorId = await BuscarPorId(id);

            if (ProjetoPorId == null)
            {
                throw new Exception($"Projeto do ID: {id} não foi encontrado");
            }

            ProjetoPorId.NomeProjeto = projeto.NomeProjeto;
            ProjetoPorId.DataCriacao = projeto.DataCriacao;
            ProjetoPorId.DataTermino = projeto.DataTermino;
            ProjetoPorId.GerenteId = projeto.GerenteId;

            _dbContext.projetos.Update(ProjetoPorId);
            await _dbContext.SaveChangesAsync();
            return ProjetoPorId;
        }


    }
}
