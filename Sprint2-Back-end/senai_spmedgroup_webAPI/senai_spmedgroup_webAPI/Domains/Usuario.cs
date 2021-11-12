using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O campo tipo de usuario é obrigatório!")]
        [Range(1, 3, ErrorMessage = "Tipo de usuário inválido.")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório!")]
        [MinLength(8, ErrorMessage = "A senha precisa conter de 8 a 25 caracteres")]
        [MaxLength(25, ErrorMessage = "A senha precisa conter de 8 a 25 caracteres")]
        public string Senha { get; set; }
        public string NomeUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
