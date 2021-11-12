using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.ViewModels
{
    public class DescricaoViewModel
    {
        [Required(ErrorMessage = "Informe uma descrição da consulta.")]
        [MaxLength(300, ErrorMessage = "A descrição da consulta deve conter no máximo 400 caracteres.")]
        public string Descricao { get; set; }
    }
}