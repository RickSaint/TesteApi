using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestrutura.Data.Contexts
{
    public class NewContext : DbContext
    {
        public NewContext(DbContextOptions options) : base(options) { }

        public DbSet<Contato> Contato { get; set; }

        // Método de SaveChanges
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            AddCreatedAt();
            AddUpdatedAt();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        // método privado que adicionar a data de criação da entidade, onde ele verifica se a entidade foi add
        // e faz com que a propriedade CreatedAt receba da data atual.
        private void AddCreatedAt() =>
            ChangeTracker.Entries().Where(p => p.Entity is Entity && p.State.Equals(EntityState.Added)).ToList()
                .ForEach(p => ((Entity)p.Entity).CreatedAt = DateTime.UtcNow);
        // Semelhante ao método acima, verifica a informações da entidade e caso foi modificada, na propriedade UpdateAt
        // ele recebe a data atual da modificação
        private void AddUpdatedAt() =>
            ChangeTracker.Entries().Where(p => p.Entity is Entity && p.State.Equals(EntityState.Modified)).ToList()
                .ForEach(p => ((Entity)p.Entity).UpdatedAt = DateTime.UtcNow);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
