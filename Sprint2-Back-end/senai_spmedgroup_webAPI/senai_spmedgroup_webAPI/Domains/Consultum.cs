using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "O campo paciente é obrigatório!")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "O campo médico é obrigatório!")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "O campo situação da consulta é obrigatório!")]
        public int? IdSituacao { get; set; }

        [Required(ErrorMessage = "O campo data da consulta é obrigatório!")]
        public DateTime DataConsulta { get; set; }

        [MaxLength(300, ErrorMessage = "O descrição da consulta deve conter no máximo 400 caracteres.")]
        public string DescricaoConsulta { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
