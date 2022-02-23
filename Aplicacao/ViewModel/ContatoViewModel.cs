using System;

namespace Aplicacao.ViewModel
{
    // Essa é classe a entidadeDTO, que significa obj de trasferencia de dados
    // basicamente é padrão que é usado para trasnferir dados entre subsistemas.
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsAtivo { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }

        public string MsgErro { get; set; }
        public bool Valido { get; set; }
    }
}
