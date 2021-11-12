using senai_spmedgroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista de clinica
        /// </summary>
        /// <returns>Uma lista de clinica</returns>
        List<Clinica> Listar();

        /// <summary>
        /// Busca uma clinica através de seu ID
        /// </summary>
        /// <param name="IdClinica">ID da clinica que será buscada</param>
        /// <returns>ID encontrado</returns>
        Clinica BuscarPorID(int IdClinica);

        /// <summary>
        /// Cadastra uma nova clinica 
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica com os dados que forem cadastrados</param>
        void Cadastrar(Clinica novaClinica);
        List<Clinica> ListarTodos();

        /// <summary>
        /// Atualiza uma clinica existente
        /// </summary>
        /// <param name="IdClinica">ID da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto clinicaAtualizada com as novas informações</param>
        void AtualizarPorID(int IdClinica, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="IdClinica">ID da clinica que será atualizada</param>
        bool Deletar(int IdClinica);
    }
}
