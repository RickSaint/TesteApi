using Infraestrutura.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Api.Test
{
    public abstract  class UnitTest1
    {
        public UnitTest1()
        {

        }
    }

    public class DbTest : IDisposable
    {
        // Essa linha de c�digo eu crio o nome do banco de dados com Guid pra nunca ficar repetindo
        private string dataBaseName = $"dbApiTest{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider serviceProvider { get; private set; }
        public DbTest()
        {
            // Aqui em embaixo temos o contexto criado para fazer os testes
            var serviceCollection = new ServiceCollection();
            // Esse � contexto criando para ter conex�o com banco de dados
            serviceCollection.AddDbContext<NewContext>(o =>
                o.UseSqlServer($"Server=(localdb)\\mssqllocaldb;Database={dataBaseName};Trusted_Connection=True;MultipleActiveResultSets=true"),
                ServiceLifetime.Transient
            );
            // Linha de codigo que vai criar o banco de dados
            serviceProvider = serviceCollection.BuildServiceProvider();
            using (var context = serviceProvider.GetService<NewContext>())
            {
                context.Database.EnsureCreated();
            }
        }


        public void Dispose()
        {
            // Linha de condigo que vai deletar o bd quando pararmos de usar
            using (var context = serviceProvider.GetService<NewContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
