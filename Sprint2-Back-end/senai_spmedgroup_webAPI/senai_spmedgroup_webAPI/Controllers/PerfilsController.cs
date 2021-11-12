using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedicalGroupWebApi.Interfaces;
using SPMedicalGroupWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public PerfilsController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Posta uma foto como foto de perfil de um determinado usuario
        /// </summary>
        /// <param name="arquivo">Arquivo de foto (png)</param>
        /// <returns></returns>
        [Authorize(Roles = "2,3")]
        [HttpPost("imagem/dir")]
        public IActionResult PostDir(IFormFile arquivo)
        {
            try
            {
                if (arquivo == null) return BadRequest(new { mensagem = "Arquivo não enviado" });

                //analise de tamanho do arquivo.
                if (arquivo.Length > (5 * 1024 * 1024)) //5MB
                    return BadRequest(new { mensagem = "O tamanho máximo da imagem foi atingido." });

                string extensao = arquivo.FileName.Split('.').Last();

                if (extensao != "png")
                    return BadRequest(new { mensagem = "Apenas arquivos .png são permitidos." });


                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                _usuarioRepository.SalvarPerfilDir(arquivo, idUsuario);

                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Consulta a foto do usuário
        /// </summary>
        /// <returns>Retorna a imagem em bytes</returns>
        [Authorize(Roles = "2,3")]
        [HttpGet("imagem/dir")]
        public IActionResult GetDir()
        {
            try
            {

                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                string base64 = _usuarioRepository.ConsultarFotoDir(idUsuario);

                return Ok(base64);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}