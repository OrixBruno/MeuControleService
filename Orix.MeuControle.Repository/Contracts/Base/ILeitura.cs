using System;
using System.Collections.Generic;

namespace Orix.MeuControle.Repository.Contracts.Base
{
    interface ILeitura<TClasse>
    {
        TClasse Buscar(Int32 id);

        List<TClasse> Listar();
    }
}
