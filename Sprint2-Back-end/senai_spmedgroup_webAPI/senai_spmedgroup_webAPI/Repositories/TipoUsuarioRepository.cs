using Microsoft.EntityFrameworkCore;
using senai_spmedgroup_webAPI.Contexts;
using senai_spmedgroup_webAPI.Domains;
using SPMedicalGroupWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroupWebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SPMedGroupContext ctx = new SPMedGroupContext();

        public void AtualizarPorID(int IdTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarUrl(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoUsuario = ctx.TipoUsuarios.Find(idTipoUsuario);

            if (tipoUsuario != null)
            {
                tipoUsuario.NomeTipoUsuario = tipoUsuarioAtualizado.NomeTipoUsuario;

                ctx.Update(tipoUsuario);

                ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios
                .Select(t => new TipoUsuario()
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    NomeTipoUsuario = t.NomeTipoUsuario
                })
                .FirstOrDefault(t => t.IdTipoUsuario == idTipoUsuario);
        }

        public TipoUsuario BuscarPorID(int IdTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(idTipoUsuario));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios
                .Select(t => new TipoUsuario()
                {
                    IdTipoUsuario = t.IdTipoUsuario,
                    NomeTipoUsuario = t.NomeTipoUsuario
                })
                .ToList();
        }
    }
}