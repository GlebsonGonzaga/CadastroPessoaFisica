using System;
using System.Collections.Generic;
using System.Linq;
using Cadastro.Model;
using Cadastro.Model.Excecoes;
using NUnit.Framework;

namespace Cadastro.Modelo.Testes.Modelo
{
   [TestFixture]
   public class FisicaTest
    {
       Fisica _pessoaFisica;

       [Test]
       public void CompararPessoaFisicaTest()
       {
           var lista = new List<Fisica>();
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "971.852.593-82", Email = "gle@bol.com", Sexo = char.Parse("m") };
           lista.Add(_pessoaFisica);
           var esperado = lista;
           var atual = esperado.ToList();
           Assert.AreEqual(esperado, atual);
       }

       [Test]
       public void CadastrarPessoaFisicaTest()
       {
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "871.852.323/02", Email = "gle@bol.com", Idade = 30, Sexo = char.Parse("m") };
           _pessoaFisica.AdicionarTelefone(new Guid(), "Celular", 021, 52859563);
           Telefone atual = _pessoaFisica.Telefones.FirstOrDefault(tel => tel.Numero == 52859563);
           Assert.Contains(atual, _pessoaFisica.Telefones);
       }

       [Test]
       public void ExcluirPessoaFisicaTest()
       {
           var lista = new List<Fisica>();
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "871.852.323/02", Email = "gle@bol.com", Idade = 30, Sexo = char.Parse("m") };
           _pessoaFisica.AdicionarTelefone(new Guid(), "Celular", 021, 52859563);
           lista.Remove(_pessoaFisica);
           var esperado = lista;
           Telefone atual = _pessoaFisica.Telefones.FirstOrDefault(tel => tel.Numero == 52859563);
           Assert.AreNotEqual(atual, esperado);
       }

     
       [Test]
       public void IncluirTelefonesTest()
       {
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "871.852.323/02", Email = "gle@bol.com", Idade = 30, Sexo = char.Parse("m") };
           _pessoaFisica.AdicionarTelefone(new Guid(), "Celular", 021, 52859563);
           Telefone atual = _pessoaFisica.Telefones.FirstOrDefault(t => t.Numero == 52859563);
           Assert.Contains(atual, _pessoaFisica.Telefones);
       }
       [Test]
       public void IncluirTelefoneExistente()
       {
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "871.852.323/02", Email = "gle@bol.com", Idade = 30, Sexo = char.Parse("m")};
           _pessoaFisica.AdicionarTelefone(new Guid(), "Celular", 021, 93967487);
           Assert.Throws<ExTelefoneExistente>(delegate { _pessoaFisica.AdicionarTelefone(new Guid(), "Celular", 021, 93967487); });
       }

       [Test]
       public void ExcluirTelefone()
       {
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "871.852.323/02", Email = "gle@bol.com", Idade = 30, Sexo = char.Parse("m") };
           _pessoaFisica.AdicionarTelefone(new Guid(), "Residencial", 021, 29280923);
           _pessoaFisica.ExcluirTelefone(021, 29280923);
           const int atual = 0;
           var esperado = _pessoaFisica.Telefones.Count();
           Assert.AreEqual(esperado, atual);
       }
       [Test]
       public void ExcluirTelefoneInexistente()
       {
           _pessoaFisica = new Fisica { Nome = "Glebson Lima", CPF = "871.852.323/02", Email = "gle@bol.com", Idade = 30, Sexo = char.Parse("m") };
           Assert.Throws<ExTelefoneInexistente>(delegate { _pessoaFisica.ExcluirTelefone(021, 87200012); });
       }
           
    }
}
