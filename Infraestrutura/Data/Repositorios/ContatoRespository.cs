using Dominio.Entidades;
using Infraestrutura.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Data.Repositorios
{
    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(NewContext context) : base(context) { }
    }
}
