using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Interfaces
{
    public interface IProjetoRepositorio
    {
        Task<List<ProjetoModel>> BuscarTodosProjetos();
        Task<ProjetoModel> BuscarPorId(int Id);
        Task<ProjetoModel> Adicionar(ProjetoModel projeto);

        Task<ProjetoModel> Atualizar(ProjetoModel projeto, int Id);
        Task<bool> Apagar(int Id);


    }
}
