using Aplicacao.ViewModel;
using System;


namespace Aplicacao.Validation
{
    // Classe responsavel por fazer as validações da entidade
    public class ValidarContato
    {
        // Método que valida se a data de nascimento é maior que da data atual
        // então ocorre um disparo de erro comunicando.
        // A outra validação é de a idade é menor que 18, caso seja ocorre um desparo de uma msg erro.
        public static ErrorMessage ValidarDados(ContatoViewModel obj)
        {
            var validacao = new ErrorMessage() { Valido = true };

            if (obj.DataNascimento.Date > DateTime.Today)
            {
                validacao = new ErrorMessage() { Valido = false, Erro = "Data de nascimento é maior que a data atual" };
                return validacao;
            }

            if (obj.Idade < 18)
                validacao = new ErrorMessage() { Valido = false, Erro = "O contato tem que ser maior de idade" };

            return validacao;
        }

        // Esse método é estatico e retorna um int, ele faz toda a tratativa
        // da data de nascimento da entidade e faz a operação de diminuir o ano 
        // da entidade e ano atual. Depois cai numa condição que vai comparar se
        // dia do ano é menor que da data de nascimento da entidade, se for ele diminue 1.
        public static int CalcularIdade(ContatoViewModel obj)
        {
            var dataNascimento = obj.DataNascimento;
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
    }
}
