namespace Aplicacao.ViewModel
{
    // Classe responsavel por gerenciar e armazenar msg erro,
    // caso a entidade é valido e msg de erro.
    public class ErrorMessage
    {
        public bool Valido { get; set; }
        public string Erro { get; set; }
    }
}
