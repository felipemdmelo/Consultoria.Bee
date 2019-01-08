using System;
using System.Collections.Generic;
using System.Text;

namespace Consultoria.Bee.Domain.Entities.Base
{
    public abstract class AbstractEntity
    {
        public long Id { get; set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataInativacao { get; private set; }
        
        public AbstractEntity()
        {
            IsAtivo = true;
            DataCadastro = DateTime.Now;
        }

        public void Inativar()
        {
            IsAtivo = false;
            DataInativacao = DateTime.Now;
        }
    }
}
