namespace SistemaDeCadastro.Models
{
    public class ProjetoModel
    {
        public int IdProjeto { get; set; }
        public string? NomeProjeto { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime? DataTermino { get; set; }

        public int? GerenteId { get; set; }

        public virtual EmpregadoModel? Gerente { get; set; }

        


        


    }
}

