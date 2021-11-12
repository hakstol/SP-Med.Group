using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todos as Situações
        /// </summary>
        /// <returns></returns>
        List<Situacao> ListarTodos();

        /// <summary>
        /// Busca uma Situacao através do id
        /// </summary>
        /// <param name="IdSituacao">Id da Situacao a ser buscada</param>
        /// <returns></returns>
        Situacao BuscarPorID(int IdSituacao);

        /// <summary>
        /// Cadastra uma nova Situacao
        /// </summary>
        /// <param name="novaSituacao">Objeto Situacao a ser cadastrado</param>
        void Cadastrar(Situacao novaSituacao);

        /// <summary>
        /// Deleta uma Situacao através do id
        /// </summary>
        /// <param name="IdSituacao">Id da Situacao a ser deletada</param>
        void Deletar(int IdSituacao);

        /// <summary>
        /// Atualiza uma Situacao através do id
        /// </summary>
        /// <param name="IdSituacao">Id da Situacao a ser atualizada</param>
        /// <param name="SituacaoAtualizada">Objeto Situacao a ser atualizado</param>
        void AtualizarPorID(int IdSituacao, Situacao SituacaoAtualizada);
    }
}