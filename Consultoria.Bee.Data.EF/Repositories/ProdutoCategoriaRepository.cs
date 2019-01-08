using Consultoria.Bee.Data.EF.Context;
using Consultoria.Bee.Domain.Entities;
using Consultoria.Bee.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Bee.Data.EF.Repositories
{
    public class ProdutoCategoriaRepository : GenericRepository<ProdutoCategoria>, IProdutoCategoriaRepository
    {
        public ProdutoCategoriaRepository(BeeContext db) : base(db)
        { }
    }
}
