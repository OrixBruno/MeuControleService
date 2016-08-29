using System;

namespace Orix.MeuControle.Repository.Contracts.Base
{
    interface IGravacao<TClasse>
    {
        TClasse Cadastrar(TClasse dadosTela);

        void Editar(TClasse dadosTela);

        void Excluir(Int32 id);
    }
}
