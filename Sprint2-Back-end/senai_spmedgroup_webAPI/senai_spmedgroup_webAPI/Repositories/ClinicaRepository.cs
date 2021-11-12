using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SPMedGroupContext ctx = new SPMedGroupContext();

        public void AtualizarPorID(int IdClinica, Clinica clinicaAtualizada)
        {
            throw new NotImplementedException();
        }

        public void AtualizarUrl(int IdClinica, Clinica ClinicaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorID(int IdClinica)
        {
            return ctx.Clinicas.FirstOrDefault(u => u.IdClinica == IdClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public bool Deletar(int IdClinica)
        {
            Clinica clinicaBuscada = BuscarPorID(IdClinica);

            if (clinicaBuscada == null) return false;

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();

            return true;
        }

        public List<Clinica> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas
                    .ToList();
        }
    }
}