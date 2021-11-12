using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public int? IdEndereco { get; set; }

        [MaxLength(18, ErrorMessage = "O nome da clínica deve conter no máximo 55 caracteres.")]
        public string NomeClinica { get; set; }

        [Required(ErrorMessage = "O campo CNPJ é obrigatório!")]
        [MaxLength(18, ErrorMessage = "O CNPJ deve conter no máximo 18 caracteres.")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo razão social é obrigatório!")]
        [MaxLength(18, ErrorMessage = "A razão social deve conter no máximo 200 caracteres.")]
        public string RazaoSocial { get; set; }

        [MaxLength(15, ErrorMessage = "O telefone deve conter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
