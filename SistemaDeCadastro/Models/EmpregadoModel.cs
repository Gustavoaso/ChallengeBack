namespace SistemaDeCadastro.Models
{
    public class EmpregadoModel
    {
        public int IdEmpregado { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string?  Telefone { get; set; }

        public string? Endereco { get; set; }


    }
}
