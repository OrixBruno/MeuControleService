using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orix.MeuControle.Repository.Implementation;
using Orix.MeuControle.Repository.Contracts;

namespace MeuControle.Api.Test
{
    [TestClass]
    public class TesteRepository
    {
        private readonly IAutenticacaoRepository _authRepository;
        public TesteRepository(IAutenticacaoRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [TestMethod]
        public void ContaExiste()
        {
            _authRepository.Login(new Orix.MeuControle.Domain.ContaDomainModel() { Usuario = "Bruno", Senha = "123" });
        }
    }
}
