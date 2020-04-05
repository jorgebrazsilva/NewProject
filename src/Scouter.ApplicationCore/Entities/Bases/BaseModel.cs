using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.Entities.Bases
{
    public abstract class BaseModel<T> : BaseEntity<T> where T : BaseEntity<T>
    {
        public long Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public Guid IdUsuario { get; protected set; }

        public virtual Usuario Usuario { get; protected set; }

        protected BaseModel(string nome, string descricao, bool ativo, Guid idUsuario)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            IdUsuario = idUsuario;
        }
    }
}
