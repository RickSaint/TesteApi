using Infraestrutura.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Test
{
    public class UserCrud : UnitTest1, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public UserCrud(DbTest dbTest)
        {
            _serviceProvider = dbTest.serviceProvider;
        }

        [Fact(DisplayName = "CRUD - Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            using (var context = _serviceProvider.GetService<NewContext>())
            {
                //UserImplementation _repository = new UserImplementation(context);
                //var _entity = new UserEntity()
                //{
                //    // Eu posso instalar um pacote chamado Faker.NetCore que ele vai gerar 
                //    // informações que queria testar. No meu caso eu estou gerando Email e Nome
                //    Email = Faker.Internet.Email(),
                //    Nome = Faker.Name.FullName()
                //};

                //// TESTE DO CREATE
                //var registroCriado = await _repository.InsertAsync(_entity);
                //Assert.NotNull(registroCriado); // O registro no banco não pode ser nullo
                //Assert.Equal(_entity.Email, registroCriado.Email); // comparação da propriedade email se são iguais
                //Assert.Equal(_entity.Nome, registroCriado.Nome); // comparação da propriedade nome se são iguais
                //Assert.False(registroCriado.Id == Guid.Empty);

                //// TESTE DE UPDATE
                //_entity.Nome = Faker.Name.First();
                //var registroAtualizado = await _repository.UpdateAsync(_entity);
                //Assert.NotNull(registroAtualizado);
                //Assert.Equal(_entity.Email, registroAtualizado.Email);
                //Assert.Equal(_entity.Nome, registroAtualizado.Nome);

                //// TESTE SE EXISTE O REGISTRO
                //var registroExist = await _repository.ExistAsync(registroAtualizado.Id);
                //Assert.True(registroExist);

                //// TESTE DO SELECT BY ID
                //var registroSelecionado = await _repository.SelectAsync(registroAtualizado.Id);
                //Assert.NotNull(registroSelecionado);
                //Assert.Equal(registroAtualizado.Email, registroSelecionado.Email);
                //Assert.Equal(registroAtualizado.Nome, registroSelecionado.Nome);

                //// TESTE DO GET ALL
                //var _todoregistro = await _repository.SelectAsync();
                //Assert.NotNull(_todoregistro);
                //Assert.True(_todoregistro.Count() > 0);

                //// TESTE DO DELETE
                //var removeu = await _repository.DeleteAsync(registroSelecionado.Id);
                //Assert.True(removeu);

                //var usuarioPadrao = await _repository.FindByLogin("adm@gmail.com");
                //Assert.NotNull(usuarioPadrao);
                //Assert.Equal("adm@gmail.com", usuarioPadrao.Email);
                //Assert.Equal("Administrador", usuarioPadrao.Nome);

            }
        }
    }
}
