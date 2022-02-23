using System;

namespace Dominio.Entidades
{
    public class Contato : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsAtivo { get; set; }
        public string Sexo { get; set; }
        public int? Idade { get; set; }
    }
}
