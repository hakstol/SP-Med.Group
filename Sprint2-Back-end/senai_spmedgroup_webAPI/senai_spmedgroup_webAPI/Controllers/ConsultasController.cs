using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using senai_spmedgroup_webAPI.Repositories;
using SPMedicalGroupWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas a consultas
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<Consultum> lista = _consultaRepository.ListarTodos();

                return Ok(lista);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta (Agenda consulta)
        /// </summary>
        /// <param name="novaConsultaModel">Dados da consulta a ser agendada</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(ConsultaViewModel novaConsultaModel)
        {
            try
            {
                Consultum novaConsulta = new Consultum()
                {
                    IdSituacao = 3,
                    IdPaciente = novaConsultaModel.IdPaciente,
                    IdMedico = novaConsultaModel.IdMedico,
                    DataConsulta = novaConsultaModel.DataConsulta
                };

                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cancela uma consulta através do seu id
        /// </summary>
        /// <param name="id">Id da consulta a ser cancelada</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPatch("cancelar/{id}")]
        public IActionResult Cancel(int id)
        {
            try
            {
                bool created = _consultaRepository.Cancelar(id);

                if (created)
                {
                    return NoContent();
                }
                return NotFound(
                        new
                        {
                            mensagem = "Consulta não encontrada ou já realizada.",
                            erro = true
                        }

                    );
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Altera a situação da consulta através do seu id
        /// </summary>
        /// <param name="idConsulta">id da consulta que terá a situação alterada</param>
        /// <param name="consultaModel">Nova situação da consulta</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPatch("alterar/situacao/{idConsulta}")]
        public IActionResult AlterSituation(int idConsulta, SituacaoViewModel consultaModel)
        {
            if (consultaModel.IdSituacao <= 0 || consultaModel.IdSituacao > 3)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Id da situação inválido.",
                            erro = true
                        }
                    );
            }
            try
            {
                _consultaRepository.AlterarSituacao(idConsulta, consultaModel.IdSituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Lista as consultas relacionadas a um determinado usuário (médico ou paciente)
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2,3")]
        [HttpGet("Listar/Minhas")]
        public IActionResult ListarMinhas()
        {
            {
                try
                {

                    int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                    int idTipoUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value);
                    List<Consultum> listarMinhas = _consultaRepository.ListarMinhas(idUsuario, idTipoUsuario);

                    if (listarMinhas.Count == 0)
                    {
                        return NotFound(new
                        {
                            Mensagem = "Não existe consulta com esse usuário"
                        });
                    }

                    if (idTipoUsuario == 3)
                    {
                        return Ok(new
                        {
                            Mensagem = $"O paciente buscado tem {_consultaRepository.ListarMinhas(idUsuario, idTipoUsuario).Count} consultas",
                            listarMinhas
                        });
                    }
                    if (idTipoUsuario == 2)
                    {
                        return Ok(new
                        {
                            Mensagem = $"O médico buscado tem {_consultaRepository.ListarMinhas(idUsuario, idTipoUsuario).Count} consultas",
                            listarMinhas
                        });
                    }
                    return null;

                }
                catch (Exception error)
                {

                    return BadRequest(error.Message);
                }
            }
        }

        /// <summary>
        /// Altera a descrição de uma consulta 
        /// </summary>
        /// <param name="idConsulta">Id da consulta que terá a descrição alterada</param>
        /// <param name="descricao">Nova descrição da consulta</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPatch("alterar/descricao/{idConsulta}")]
        public IActionResult AlterDescription(int idConsulta, DescricaoViewModel descricao)
        {
            try
            {
                if (idConsulta <= 0)
                {
                    return NotFound(
                            new
                            {
                                mensagem = "Id inválido.",
                                erro = true
                            }
                        );
                }
                int idMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                bool altered = _consultaRepository.AtualizarDescricao(idConsulta, idMedico, descricao);

                if (altered) return NoContent();

                return NotFound(
                        new
                        {
                            mensagem = "Consulta não encontrada ou Médico não responsável pela consulta.",
                            erro = true
                        }
                    );
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}