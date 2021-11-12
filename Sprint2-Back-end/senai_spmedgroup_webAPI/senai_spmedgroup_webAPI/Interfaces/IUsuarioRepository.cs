using Microsoft.AspNetCore.Http;
using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns></returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Busca um Usuario através do id
        /// </summary>
        /// <param name="IdUsuario">Id do Usuario a ser buscado</param>
        /// <returns></returns>
        Usuario BuscarPorID(int IdUsuario);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto Usuario a ser cadastrado</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Deleta um Usuario através do id
        /// </summary>
        /// <param name="IdUsuario">Id do usuario a ser deletado</param>
        void Deletar(int IdUsuario);

        /// <summary>
        /// Atualiza um Usuario através do id
        /// </summary>
        /// <param name="IdUsuario">Id do Usuario a ser atualizado</param>
        /// <param name="usuarioAtualizado">Objeto Usuario a ser atualizado</param>
        void AtualizarPorID(int IdUsuario, Usuario usuarioAtualizado);

        /// <summary>
        /// Busca um usuario através do email e senha
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns></returns>
        Usuario Login(string email, string senha);

        /// <summary>
        /// Salva uma foto de perfil do usuario
        /// </summary>
        /// <param name="foto">Foto a ser salva</param>
        /// <param name="idUsuario">Id do usuário que possui a foto</param>
        void SalvarPerfilDir(IFormFile foto, int idUsuario);

        /// <summary>
        /// Consulta o arquivo da foto de um determinado usuário
        /// </summary>
        /// <param name="idUsuario">Id do usuário que possui a foto</param>
        /// <returns></returns>
        string ConsultarFotoDir(int idUsuario);
    }
}