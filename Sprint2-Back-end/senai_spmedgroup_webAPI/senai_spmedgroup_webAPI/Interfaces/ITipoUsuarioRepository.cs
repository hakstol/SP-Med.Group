using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os TiposUsuarios
        /// </summary>
        /// <returns></returns>
        List<TipoUsuario> ListarTodos();

        /// <summary>
        /// Busca um TipoUsuario através do id
        /// </summary>
        /// <param name="IdTipoUsuario">Id do TipoUsuario a ser buscado</param>
        /// <returns></returns>
        TipoUsuario BuscarPorID(int IdTipoUsuario);

        /// <summary>
        /// Cadastra um novo TipoUsuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto TipoUsuario a ser cadastrado</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Deleta um TipoUsuario através do id
        /// </summary>
        /// <param name="IdTipoUsuario">Id tipo usuario a ser deletado</param>
        void Deletar(int IdTipoUsuario);

        /// <summary>
        /// Atualiza um TipoUsuario através do id
        /// </summary>
        /// <param name="IdTipoUsuario">Id do TipoUsuario a ser atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto TipoUsuario a ser atualizado</param>
        void AtualizarPorID(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado);
    }
}