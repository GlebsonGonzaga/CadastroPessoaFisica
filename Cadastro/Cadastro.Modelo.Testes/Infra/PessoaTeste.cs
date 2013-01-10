using System;
using Cadastro.DAL;
using Cadastro.Model;
using NUnit.Framework;

namespace Cadastro.Modelo.Testes.Infra
{
    [TestFixture]
    public class PessoaTeste
    {
    [Test]
        public void TestaInsertNoBanco()
        {
            var fisica = new Fisica
                             {
                                 Id = Guid.NewGuid(),
                                 Nome = "Ubirajara Mendes",
                                 Idade = 29,
                                 Sexo = char.Parse("m"),
                                 Email = "bira@bira.com",
                                 CPF = "794.785.896-25"
                             };
            var dao = Factory.DaoFactory.GetFisicaDao();
            dao.Insert(fisica);
            var telefone = new Telefone(fisica.Id,"Celular", 021, 25858965);
            var daoTel = Factory.DaoFactory.GetTelefoneDao(); 
            daoTel.Insert(telefone);
        }

       [Test]
        public void TestaSelectNoBancoPorId()
        {
            const string guid = @"6b7445c2-1505-46a0-8e55-709db5aaf38e";
            var dao = Factory.DaoFactory.GetFisicaDao();
            var daoTel = Factory.DaoFactory.GetTelefoneDao();
            var fisica = dao.Get(Guid.Parse(guid));
            var telefone = daoTel.Get(Guid.Parse(guid));
          
        }

    

       [Test]
       public void TestaSelectNoBanco()
       {
           var dao = Factory.DaoFactory.GetFisicaDao();
           var daoTel = Factory.DaoFactory.GetTelefoneDao();
           var fisica = dao.GetAll();
           var telefone = daoTel.GetAll();

       }

        [Test]
        public void TestaDeleteNoBanco()
       {
           var fisica = new Fisica { Id = Guid.Parse("6b7445c2-1505-46a0-8e55-709db5aaf38e") };
            var telefone = new Telefone(fisica.Id, "Celular", 021, 85479685);
            var daoTel = Factory.DaoFactory.GetTelefoneDao();
            daoTel.Delete(telefone);
            var dao = Factory.DaoFactory.GetFisicaDao();
            dao.Delete(fisica);
 
        }

        [Test]
        public void TestaUpdateNoBanco()
        {
            var fisica = new Fisica { Id = Guid.Parse("6b7445c2-1505-46a0-8e55-709db5aaf38e"), Nome = "Tomoru Shindo" };
            var dao = Factory.DaoFactory.GetFisicaDao();
            dao.Update(fisica);
            var telefone = new Telefone(fisica.Id, "Celular", 021, 25749696);
            var daoTel = Factory.DaoFactory.GetTelefoneDao();
            daoTel.Update(telefone);
        }

    }
}