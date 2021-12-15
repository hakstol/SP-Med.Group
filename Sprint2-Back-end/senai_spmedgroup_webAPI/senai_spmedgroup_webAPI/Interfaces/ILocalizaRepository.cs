using senai_spmedgroup_webAPI.Domains;
using System.Collections.Generic;


namespace senai_spmedgroup_webAPI.Interfaces
{
    interface ILocalizaRepository
    {
        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao novaLocalizacao);
    }
}
