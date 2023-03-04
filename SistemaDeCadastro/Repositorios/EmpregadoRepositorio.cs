using SistemaDeCadastro.Data;
using SistemaDeCadastro.Models;
using SistemaDeCadastro.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace SistemaDeCadastro.Repositorios
{
    public class EmpregadoRepositorio : IEmpregadoRepositorio
    {       
 
              private readonly SistemaDeCadastroDBContext _dbContext;

        public EmpregadoRepositorio(SistemaDeCadastroDBContext sistemaDeCadastroDBContext) 
        { 
            _dbContext = sistemaDeCadastroDBContext;
        }
        public async Task<EmpregadoModel> BuscarPorId(int id)
        {
            return await _dbContext.empregados.FirstOrDefaultAsync(x=> x.IdEmpregado == id);
        }

        public async Task<List<EmpregadoModel>> BuscarTodosEmpregados()
        {
            return await _dbContext.empregados.ToListAsync();
        }
        public async Task<EmpregadoModel> Adicionar(EmpregadoModel empregado)
        {
            
              await _dbContext.empregados.AddAsync(empregado);
            await _dbContext.SaveChangesAsync();
            return empregado;
        }

        public async Task<bool> Apagar(int id)
        {
             EmpregadoModel EmpregadoPorId = await BuscarPorId(id);

            if (EmpregadoPorId == null)
            {
                throw new Exception($"Usuario do ID: {id} não foi encontrado");
            }
            else
            {
                _dbContext.empregados.Remove(EmpregadoPorId);
                await _dbContext.SaveChangesAsync();

            }
           return true;
        }

        public async Task<EmpregadoModel> Atualizar(EmpregadoModel empregado, int id)
        {
           EmpregadoModel EmpregadoPorId = await BuscarPorId(id);

           if(EmpregadoPorId == null)
           {
                throw new Exception($"Usuario do ID: {id} não foi encontrado");
           }

           EmpregadoPorId.PrimeiroNome = empregado.PrimeiroNome;
           EmpregadoPorId.UltimoNome = empregado.UltimoNome;
           EmpregadoPorId.Telefone = empregado.Telefone;
           EmpregadoPorId.Endereco = empregado.Endereco;

           _dbContext.empregados.Update(EmpregadoPorId);
           await _dbContext.SaveChangesAsync();
            return EmpregadoPorId;
        }

        
    }
}
