using System;
using System.Collections.Generic;
using Cadastro.DAL;
using Cadastro.Factory;
using Cadastro.Model;

namespace Cadastro.Repositorios
{
    public class InfraRepositorioFisica
    {
     
        private List<Fisica> pessoasFisicas;
        private IDAL<Fisica> dao = DaoFactory.GetFisicaDao();

        public void Salvar(Fisica pessoa)
        {   
            pessoa.Id = new Guid();
            pessoa.Nome = "Glebson";
            pessoa.Idade = 30;
            pessoa.Sexo = char.Parse("m");
            pessoa.Email = "glebson@bol.com";
            pessoa.CPF = "897.858.357.08";
            dao.Insert(pessoa);
            pessoasFisicas.Add(pessoa);
        
        }

        public void Excluir(Fisica pessoa)
        {
            pessoa.Nome = "Bira"; 
            pessoasFisicas.Remove(pessoa);
        }

        public void Alterar(Fisica pessoa)
        {
          
        }

     
    }

   
}
