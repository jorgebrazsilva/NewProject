using System;
using System.Linq;


namespace Scouter.ApplicationCore.ViewModels.Bases
{
    public abstract class BaseViewModel
    {
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
