using System;

namespace Scouter.ApplicationCore.Entities.Bases
{
    public abstract class BaseEntity<T>
    {
        public bool Ativo { get; protected set; }
        public Guid UsuarioId { get; protected set; }
        public DateTime DataCriacao { get; protected set; }

        public void Inativar()
        {
            Ativo = false;
        }
        public void Ativar()
        {
            Ativo = true;
        }
    }
}
