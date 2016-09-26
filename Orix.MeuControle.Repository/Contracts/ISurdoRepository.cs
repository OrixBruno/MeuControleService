﻿using Orix.MeuControle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    interface ISurdoRepository : Base.IGravacao<SurdoDomainModel>, Base.ILeitura<SurdoDomainModel>
    {
    }
}
