using System;
using System.Linq;


namespace Scouter.ApplicationCore.ViewModels.Bases
{
    public abstract class BaseViewModel
    {   
        public Guid IdUsuario { get; set; }
        public bool Ativo { get; set; }        
    }
}
