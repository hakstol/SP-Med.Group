using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todos as Especialidades
        /// </summary>
        /// <returns></returns>
        List<Especialidade> ListarTodos();

        /// <summary>
        /// Busca uma Especialidade através do id
        /// </summary>
        /// <param name="IdEspecialidade">Id da Especialidade a ser buscada</param>
        /// <returns></returns>
        Especialidade BuscarPorId(int IdEspecialidade);

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto Especialidade a ser cadastrado</param>
        void Cadastrar(Especialidade novaEspecialidade);

        /// <summary>
        /// Deleta uma Especialidade através do id
        /// </summary>
        /// <param name="IdEspecialidade">Id da Especialidade a ser deletada</param>
        void Deletar(int IdEspecialidade);

        /// <summary>
        /// Atualiza uma Especialidade através do id
        /// </summary>
        /// <param name="IdEspecialidade">Id da Especialidade a ser atualizada</param>
        /// <param name="EspecialidadeAtualizada">Objeto Especialidade a ser atualizado</param>
        void AtualizarUrl(int IdEspecialidade, Especialidade EspecialidadeAtualizada);
    }
}