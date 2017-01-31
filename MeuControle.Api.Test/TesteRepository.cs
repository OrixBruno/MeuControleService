using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orix.MeuControle.Repository.Implementation;

namespace MeuControle.Api.Test
{
    [TestClass]
    public class TesteRepository
    {
        AutenticacaoRepository _authRepository = new AutenticacaoRepository();
        [TestMethod]
        public void ContaExiste()
        {
            _authRepository.Login(new Orix.MeuControle.Domain.ContaDomainModel() { Usuario = "Bruno", Senha = "123" });
        }
    }
}
