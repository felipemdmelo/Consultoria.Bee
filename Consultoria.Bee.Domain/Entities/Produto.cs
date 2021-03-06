﻿using Consultoria.Bee.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Bee.Domain.Entities
{
    public class Produto : AbstractEntity
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        #region RELACIONAMENTOS..
        public long CategoriaId { get; set; }
        public virtual ProdutoCategoria Categoria { get; set; }
        #endregion
    }
}
