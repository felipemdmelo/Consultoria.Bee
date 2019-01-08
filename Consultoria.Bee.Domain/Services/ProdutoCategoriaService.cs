using Consultoria.Bee.Domain.Entities;
using Consultoria.Bee.Domain.Interfaces.Repositories;
using Consultoria.Bee.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Bee.Domain.Services
{
    public class ProdutoCategoriaService : GenericService<ProdutoCategoria>, IProdutoCategoriaService
    {
        private readonly IProdutoCategoriaRepository _repository;

        public ProdutoCategoriaService(IProdutoCategoriaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
