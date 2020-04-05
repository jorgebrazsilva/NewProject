using Scouter.ApplicationCore.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Scouter.ApplicationCore.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "{0} inválido")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Nome")]
        [MaxLength(100, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        [MaxLength(14, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Telefone { get; set; }

        [Display(Name = "Usuário bloqueado?")]
        public bool Bloqueado { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Perfil")]
        public string PerfilName { get; set; }
       
    }
}
