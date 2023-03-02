using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Interfaces
{
    public interface IEmpregadoRepositorio
    {
        Task<List<EmpregadoModel>> BuscarTodosEmpregados();
        Task<EmpregadoModel>  BuscarPorId(int Id);
        Task<EmpregadoModel> Adicionar (EmpregadoModel empregado);

        Task<EmpregadoModel> Atualizar(EmpregadoModel empregado, int Id);
        Task<bool> Apagar(int Id);  


    }
}
