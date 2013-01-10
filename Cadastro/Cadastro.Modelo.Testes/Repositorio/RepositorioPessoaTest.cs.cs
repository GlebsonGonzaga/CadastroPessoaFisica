using System;
using Cadastro.Model;
using Cadastro.Repositorios;
using NUnit.Framework;

namespace Cadastro.Modelo.Testes.Repositorio
{
    [TestFixture]
   public class RepositorioPessoaTest
    {
        RepositorioPessoa _repositorioPessoa;
        RepositorioFisica _rFisica;

        public RepositorioPessoaTest()
        {
            _repositorioPessoa = RepositorioPessoa.Instancia();
            _rFisica = RepositorioFisica.Instancia();
          
        }
               [Test]
        public Fisica IncluirUmPessoaFisica(String pCPF)
        {
            var pFisica = new Fisica { Nome = "Glebson Lima", CPF = pCPF, Email = "gle@bol.com", Sexo = char.Parse("m") }; 
            pFisica.AdicionarTelefone(new Guid(), "Celular",021,88900092);
            _rFisica.Inserir(pFisica);
            return pFisica;
        }
        [Test]
        public void TestarInstanciaUnica()
        {
            var repositorioCliente1 = _repositorioPessoa;
            var repositorioCliente2 = RepositorioPessoa.Instancia();
            Assert.AreSame(repositorioCliente1, repositorioCliente2);
        }
    }
}
