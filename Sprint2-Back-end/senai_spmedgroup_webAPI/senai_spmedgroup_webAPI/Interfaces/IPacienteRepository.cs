using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os Pacientes
        /// </summary>
        /// <returns></returns>
        List<Paciente> ListarTodos();

        /// <summary>
        /// Busca um Paciente através do id
        /// </summary>
        /// <param name="IdPaciente">Id do Paciente a ser buscado</param>
        /// <returns></returns>
        Paciente BuscarPorID(int IdPaciente);

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto Paciente a ser cadastrado</param>
        bool Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Deleta um Paciente através do id
        /// </summary>
        /// <param name="IdPaciente">Id do Paciente a ser deletado</param>
        void Deletar(int IdPaciente);

        /// <summary>
        /// Atualiza um Paciente através do id
        /// </summary>
        /// <param name="IdPaciente">Id do Paciente a ser atualizado</param>
        /// <param name="PacienteAtualizado">Objeto Paciente a ser atualizado</param>
        void AtualizarPorID(int IdPaciente, Paciente PacienteAtualizado);
    }
}