using System;
using System.Linq;
using Cadastro.Model;
using NUnit.Framework;
using System.Reflection;

namespace Cadastro.Modelo.Testes.Modelo
{
     [TestFixture]
  public class PessoaTest
    {
           [Test]
      public void ObterAtributos()
      {
          var pessoafisica = new Fisica();
          Int32 atual = pessoafisica.GetType().GetProperties().Count();
          const int esperado = 8;
          Assert.AreEqual(esperado, atual);
      }
           [Test]
      public void ObterMetodos()
      {
          var pessoafisica = new Fisica();
          Int32 atual = pessoafisica.GetType().GetMethods().Count();
          const int esperado = 21;
          Assert.AreEqual(esperado, atual);
      }

           [Test]
      public void AtribuirValorEmNome()
      {
          var pessoafisica = new Fisica();
          const string esperado = "Marcela";
          String atual = null;
          PropertyInfo[] campos = pessoafisica.GetType().GetProperties();

          pessoafisica.Nome = "Glebson";

          foreach (PropertyInfo campo in campos)
          {
              if (campo.Name == "Nome")
              {
                  campo.SetValue(pessoafisica, "Marcela", null);
                  atual = campo.GetValue(pessoafisica, null).ToString();
              }
          }

          Assert.AreEqual(esperado, atual);
      }
    }
}
