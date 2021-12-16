using Microsoft.EntityFrameworkCore;
using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using senai_spmedgroup_webAPI.Interfaces;
using SPMedicalGroupWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webAPI.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedGroupContext ctx = new SPMedGroupContext();
        
        public bool AlterarSituacao(int idConsulta, string status)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == idConsulta);

            if (consultaBuscada == null) return false;

            switch (status)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;
                case "2":
                    consultaBuscada.IdSituacao = 2;
                    break;
                case "3":
                    consultaBuscada.IdSituacao = 3;
                    break;
                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();

            return true;
        }

        public void AtualizarPorID(int IdConsulta, Consultum consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consultum BuscarPorID(int IdConsulta)
        {
            return ctx.Consulta.FirstOrDefault(u => u.IdConsulta == IdConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public bool Cancelar(int IdConsulta)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == IdConsulta);

            if (consultaBuscada != null)
            {
                if (consultaBuscada.IdSituacao == 1) return false;

                consultaBuscada.IdSituacao = 2;

                ctx.Consulta.Update(consultaBuscada);

                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public void Deletar(int IdConsulta)
        {
            ctx.Consulta.Remove(BuscarPorID(IdConsulta));
        }

        List<Consultum> IConsultaRepository.ListarTodos()
        {
            {
                return ctx.Consulta
                    .Select(c => new Consultum()
                    {
                        IdConsulta = c.IdConsulta,
                        DataConsulta = c.DataConsulta,
                        DescricaoConsulta = c.DescricaoConsulta,
                        IdMedicoNavigation = new Medico()
                        {
                            IdMedico = c.IdMedicoNavigation.IdMedico,
                            IdUsuario = c.IdMedicoNavigation.IdUsuario,
                            Crm = c.IdMedicoNavigation.Crm,
                            NomeMedico = c.IdMedicoNavigation.NomeMedico,
                            IdClinicaNavigation = new Clinica()
                            {
                                NomeClinica = c.IdMedicoNavigation.IdClinicaNavigation.NomeClinica,
                                Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                                RazaoSocial = c.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial,
                                IdEndereco = c.IdMedicoNavigation.IdClinicaNavigation.IdEndereco,
                                Telefone = c.IdMedicoNavigation.IdClinicaNavigation.Telefone
                            },
                            IdEspecialidadeNavigation = new Especialidade()
                            {
                                NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                            },
                            IdUsuarioNavigation = new Usuario()
                            {
                                NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                                Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdPacienteNavigation = new Paciente()
                        {
                            IdPaciente = c.IdPacienteNavigation.IdPaciente,
                            DataNascimento = c.IdPacienteNavigation.DataNascimento,
                            NomePaciente = c.IdPacienteNavigation.NomePaciente,
                            Telefone = c.IdPacienteNavigation.Telefone,
                            Rg = c.IdPacienteNavigation.Rg,
                            Cpf = c.IdPacienteNavigation.Cpf,
                            IdEndereco = c.IdPacienteNavigation.IdEndereco,
                            IdUsuarioNavigation = new Usuario()
                            {
                                NomeUsuario = c.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                                Email = c.IdMedicoNavigation.IdUsuarioNavigation.Email
                            }
                        },
                        IdSituacaoNavigation = new Situacao()
                        {
                            IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                            NomeSituacao = c.IdSituacaoNavigation.NomeSituacao
                        }
                    })
                    .ToList();
            }
        }

        Consultum IConsultaRepository.BuscarPorId(int idConsulta)
        {
            throw new NotImplementedException();
        }

        List<Consultum> IConsultaRepository.ListarMinhas(int idUsuario, int idTipoUsuario)
        {
            if (idTipoUsuario == 2)
            {
                Medico medico = ctx.Medicos.FirstOrDefault(u => u.IdUsuario == idUsuario);

                int idMedico = medico.IdMedico;

                return ctx.Consulta
                                .Where(c => c.IdMedico == idMedico)
                                .AsNoTracking()
                                .Select(p => new Consultum()
                                {
                                    DataConsulta = p.DataConsulta,
                                    IdConsulta = p.IdConsulta,
                                    DescricaoConsulta = p.DescricaoConsulta,
                                    IdMedicoNavigation = new Medico()
                                    {
                                        Crm = p.IdMedicoNavigation.Crm,
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            NomeUsuario = p.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                                            Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email
                                        },
                                        IdClinicaNavigation = new Clinica()
                                        {
                                            NomeClinica = p.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                                        }
                                    },
                                    IdPacienteNavigation = new Paciente()
                                    {
                                        Cpf = p.IdPacienteNavigation.Cpf,
                                        Telefone = p.IdPacienteNavigation.Telefone,
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            NomeUsuario = p.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                                            Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                                        }
                                    },
                                    IdSituacaoNavigation = new Situacao()
                                    {
                                        NomeSituacao = p.IdSituacaoNavigation.NomeSituacao
                                    }


                                })
                                .ToList();
            }
            else if (idTipoUsuario == 3)
            {
                Paciente Paciente = ctx.Pacientes.FirstOrDefault(u => u.IdUsuario == idUsuario);

                short idPaciente = (short)Paciente.IdPaciente;
                return ctx.Consulta
                                .Where(c => c.IdPaciente == idPaciente)
                                .AsNoTracking()
                                .Select(p => new Consultum()
                                {
                                    DataConsulta = p.DataConsulta,
                                    IdConsulta = p.IdConsulta,
                                    IdMedicoNavigation = new Medico()
                                    {
                                        Crm = p.IdMedicoNavigation.Crm,
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            NomeUsuario = p.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario,
                                            Email = p.IdMedicoNavigation.IdUsuarioNavigation.Email,

                                        },
                                        IdClinicaNavigation = new Clinica()
                                        {
                                            NomeClinica = p.IdMedicoNavigation.IdClinicaNavigation.NomeClinica
                                        }
                                    },
                                    IdPacienteNavigation = new Paciente()
                                    {
                                        Cpf = p.IdPacienteNavigation.Cpf,
                                        Telefone = p.IdPacienteNavigation.Telefone,
                                        IdUsuarioNavigation = new Usuario()
                                        {
                                            NomeUsuario = p.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario,
                                            Email = p.IdPacienteNavigation.IdUsuarioNavigation.Email
                                        }
                                    },
                                    IdSituacaoNavigation = new Situacao()
                                    {
                                        NomeSituacao = p.IdSituacaoNavigation.NomeSituacao
                                    }
                                })
                                .ToList();
            }
            else
            {

                return null;
            }
        }

        public bool AtualizarDescricao(int IdConsulta, int IdMedico, DescricaoViewModel Consulta)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(p => p.IdConsulta == IdConsulta);
            Medico medico = ctx.Medicos.FirstOrDefault(m => m.IdUsuario == IdMedico);
            if (consultaBuscada == null) return false;
            if (medico.IdMedico != consultaBuscada.IdMedico) return false;
            consultaBuscada.DescricaoConsulta = Consulta.Descricao;
            ctx.Consulta.Update(consultaBuscada);
            ctx.SaveChanges();
            return true;
        }
    }
}