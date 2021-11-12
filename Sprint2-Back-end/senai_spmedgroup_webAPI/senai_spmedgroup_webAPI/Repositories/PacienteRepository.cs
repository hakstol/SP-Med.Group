using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using SPMedicalGroupWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPMedicalGroupWebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMedGroupContext ctx = new SPMedGroupContext();

        public void AtualizarPorID(int IdPaciente, Paciente PacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarUrl(int idPaciente, Paciente PacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPorID(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == idPaciente);
        }

        public bool Cadastrar(Paciente novoPaciente)
        {
            int? idUser = novoPaciente.IdUsuario;

            Usuario User = ctx.Usuarios.Find(idUser);

            if (User.IdTipoUsuario == 1)
            {
                if (User.Pacientes.Count == 0)
                {
                    ctx.Pacientes.Add(novoPaciente);

                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Deletar(int idPaciente)
        {
            Paciente pacienteBuscado = BuscarPorID(idPaciente);

            Usuario userPaciente = ctx.Usuarios.Find(pacienteBuscado.IdUsuario);

            ctx.Usuarios.Remove(userPaciente);

            ctx.Pacientes.Remove(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}