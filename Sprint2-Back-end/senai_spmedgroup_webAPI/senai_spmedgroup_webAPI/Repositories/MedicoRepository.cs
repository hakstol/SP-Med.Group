using Microsoft.EntityFrameworkCore;
using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using SPMedicalGroupWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SPMedGroupContext ctx = new SPMedGroupContext();

        public void AtualizarPorID(int idMedico, Medico MedicoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorID(int idMedico)
        {
            return ctx.Medicos
                .Select(c => new Medico()
                {
                    IdMedico = c.IdMedico,
                    IdUsuario = c.IdUsuario,
                    Crm = c.Crm,
                    NomeMedico = c.NomeMedico,
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeClinica = c.IdClinicaNavigation.NomeClinica,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                        IdEndereco = c.IdClinicaNavigation.IdEndereco,
                        Telefone = c.IdClinicaNavigation.Telefone
                    },
                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        NomeEspecialidade = c.IdEspecialidadeNavigation.NomeEspecialidade
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        NomeUsuario = c.IdUsuarioNavigation.NomeUsuario,
                        Email = c.IdUsuarioNavigation.Email
                    }
                })
                .FirstOrDefault(u => u.IdMedico == idMedico);
        }

        public bool Cadastrar(Medico novoMedico)
        {
            int? idUser = novoMedico.IdUsuario;

            Usuario user = ctx.Usuarios.Find(Convert.ToInt32(idUser));

            if (user.IdTipoUsuario == 3)
            {
                if (user.Medicos.Count == 0)
                {
                    ctx.Medicos.Add(novoMedico);

                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;

        }

        public void Deletar(int IdMedico)
        {
            Medico medicoBuscado = BuscarPorID(IdMedico);

            Usuario userMedico = ctx.Usuarios.Find(medicoBuscado.IdUsuario);

            ctx.Usuarios.Remove(userMedico);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos
                .Select(c => new Medico()
                {
                    IdMedico = c.IdMedico,
                    IdUsuario = c.IdUsuario,
                    Crm = c.Crm,
                    NomeMedico = c.NomeMedico,
                    IdClinicaNavigation = new Clinica()
                    {
                        NomeClinica = c.IdClinicaNavigation.NomeClinica,
                        Cnpj = c.IdClinicaNavigation.Cnpj,
                        RazaoSocial = c.IdClinicaNavigation.RazaoSocial,
                        IdEndereco = c.IdClinicaNavigation.IdEndereco,
                        Telefone = c.IdClinicaNavigation.Telefone
                    },
                    IdEspecialidadeNavigation = new Especialidade()
                    {
                        NomeEspecialidade = c.IdEspecialidadeNavigation.NomeEspecialidade
                    },
                    IdUsuarioNavigation = new Usuario()
                    {
                        NomeUsuario = c.IdUsuarioNavigation.NomeUsuario,
                        Email = c.IdUsuarioNavigation.Email
                    }
                })
                .ToList();
        }
    }
}