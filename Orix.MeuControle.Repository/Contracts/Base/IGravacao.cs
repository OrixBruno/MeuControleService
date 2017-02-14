using System;
using System.Collections.Generic;

namespace Orix.MeuControle.Repository.Contracts.Base
{
    public interface IGravacao<TClasse>
    {
        TClasse Cadastrar(TClasse dadosTela);

        void Editar(TClasse dadosTela);

        TClasse Excluir(Int32 id);

        List<TClasse> CadastrarLista(List<TClasse> listaDados);
    }
}
