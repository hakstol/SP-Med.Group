using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.ViewModels
{
    public class ConsultaViewModel
    {
        [Required(ErrorMessage = "É necessário informar o paciente.")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "É necessário informar o médico.")]
        public short? IdMedico { get; set; }

        [Required(ErrorMessage = "É necessário informar a data da consulta.")]
        public DateTime DataConsulta { get; set; }
    }
}