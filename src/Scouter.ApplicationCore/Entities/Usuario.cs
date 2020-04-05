using Scouter.ApplicationCore.Entities.Bases;
using System;
using System.Collections.Generic;

namespace Scouter.ApplicationCore.Entities
{
    public class Usuario : BaseEntity<Usuario>
    {       
        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public bool Bloqueado { get; private set; }
        public string PerfilName { get; private set; }
    }
}
