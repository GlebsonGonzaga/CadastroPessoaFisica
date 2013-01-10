using System;
using Cadastro.DAL;
using Cadastro.Model;
using NUnit.Framework;

namespace Cadastro.Modelo.Testes
{
    [TestFixture]
    public class PessoaTeste
    {
        [Test]
        public void testa_insert_no_banco()
        {
            Fisica fisica = new Fisica();
            fisica.Id = Guid.NewGuid();
            fisica.Nome = "Ubirajara Mendes";
            fisica.Idade = 29;
            fisica.Sexo = "Masculino";
            Telefone telefone = new Telefone(fisica.Id,81,85258965);
            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            IDAL<Telefone> daoTel = Factory.DaoFactory.GetTelefoneDao();
            dao.Insert(fisica);
            daoTel.Insert(telefone); 
          
        }

        [Test]
        public void testa_select_no_banco()
        {
            string guid = @"736bf683-9b2d-4632-a2eb-d42a0fb872e6";

            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            IDAL<Telefone> daoTel = Factory.DaoFactory.GetTelefoneDao();
            Fisica fisica = dao.Get(Guid.Parse(guid));

     
             Telefone telefone = daoTel.Get(Guid.Parse(guid));

        
            Assert.IsNotNull(fisica);
        }

        [Test]
        public void testa_delete_no_banco()
        {
            Fisica fisica = new Fisica();
            fisica.Id = Guid.Parse("ce4fbf2d-92f3-4c8a-90dd-be133065ea79");
            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Delete(fisica);
        }

        [Test]
        public void testa_update_no_banco()
        {
            Fisica fisica = new Fisica();
            fisica.Id = Guid.Parse("d1bd1323-fc71-4393-8a56-66b893827994");
            fisica.Nome = "Tomoru Shindo";
            IDAL<Fisica> dao = Factory.DaoFactory.GetFisicaDao();
            dao.Update(fisica);
        }

    }
}