using System;
using Cadastro.Model;
using Cadastro.Model.Excecoes;
using Cadastro.Repositorios;
using NUnit.Framework;

namespace Cadastro.Modelo.Testes.Repositorio
{
    public class RepositorioFisicaTest
    {
        readonly RepositorioFisica _rFisica;

        public RepositorioFisicaTest()
        {
            _rFisica = RepositorioFisica.Instancia();
        }
        [Test]
        public Fisica IncluirCadastro(String pCPF)
        {
            var pFisica = new Fisica {Nome = "Glebson Tomoru",CPF = pCPF, Email = "gle@bol.com", Sexo = char.Parse("m")};
            pFisica.AdicionarTelefone(new Guid(), "Celular",021,88900092);
            _rFisica.Inserir(pFisica);
            return pFisica;

        }
        [Test]
        public void Incluir()
        {
            var esperado = IncluirCadastro("971.852.593-82");
            var atual = _rFisica.ObterCPF("971.852.593-82");
            Assert.AreSame(esperado, atual);

        }
        [Test]
        public void IncluirPessoaExistente()
        {
            var pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "971.852.593-82", Email = "gle@bol.com", Sexo = char.Parse("m") };
            _rFisica.Inserir(pessoaFisica);
            Assert.Throws<ExPessoaExistente>(() => _rFisica.Inserir(pessoaFisica));
        }

        [Test]
        public void Alterar()
        {
            IncluirCadastro("971.852.593-82");
            var atual = ((Fisica) _rFisica.ObterCPF("971.852.593-82").Clone());
            atual.Nome = "Glebson Lima";
            _rFisica.Alterar(atual);
            var esperado = ((Fisica)_rFisica.ObterCPF("971.852.593-82").Clone());
            Assert.AreEqual(esperado.Nome, atual.Nome);
        }

        [Test]
        public void Remover()
        {
            var esperado= IncluirCadastro("971.852.593-82");
            _rFisica.Excluir(esperado);
        }

        [Test]
        public void RemoverClienteInexistente()
        {
            var pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "971.852.593-82", Email = "gle@bol.com", Sexo = char.Parse("m") };
            _rFisica.Excluir(pessoaFisica);

           Assert.Throws<ExPessoaInexistente>(() => _rFisica.Excluir(pessoaFisica));
        

        }

        [Test]
        public void AlterarClienteInexistente()
        {
            var pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "971.852.593-82", Email = "gle@bol.com", Sexo = char.Parse("m") };
            _rFisica.Alterar(pessoaFisica);
            Assert.Throws<ExPessoaNaoEncontrado>(() => _rFisica.Alterar(pessoaFisica));
        }
      
    }
}
