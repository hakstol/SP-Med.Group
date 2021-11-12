using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.ViewModels
{
    public class SituacaoViewModel
    {
        [Required(ErrorMessage = "Informe a situação da consulta.")]
        public byte? IdSituacao { get; set; }
    }
}