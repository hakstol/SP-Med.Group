using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public byte? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        [MinLength(8, ErrorMessage = "A senha precisa conter de 8 a 25 caracteres")]
        [MaxLength(25, ErrorMessage = "A senha precisa conter de 8 a 25 caracteres")]
        public string Senha { get; set; }
    }
}