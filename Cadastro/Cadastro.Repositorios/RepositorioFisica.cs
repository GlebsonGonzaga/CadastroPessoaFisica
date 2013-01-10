using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cadastro.Model;
using Cadastro.Model.Excecoes;
namespace Cadastro.Repositorios
{
   public class RepositorioFisica
    {
       private static RepositorioFisica instanciaDoRepositorio = null;
        private readonly List<Fisica> _lstPFisica;

        private RepositorioFisica()
        {
            _lstPFisica = new List<Fisica>();
        }

        public static RepositorioFisica Instancia()
        {
            if (instanciaDoRepositorio == null)
                instanciaDoRepositorio = new RepositorioFisica();
            return instanciaDoRepositorio;
        }
        public Fisica ObterCPF(String pCPF)
        {
            return _lstPFisica.Where(c => c.CPF == pCPF).Cast<Fisica>().FirstOrDefault();
        }
        public void Inserir(Fisica pFisica)
        {
            var pessoafisica = ObterCPF(pFisica.CPF);
            if (pessoafisica != null)
            {
                throw new ExPessoaExistente("Cliente já existe");
            }
            else
            {
                _lstPFisica.Add(pFisica);
            }
              
           
        
        }
        public void Excluir(Fisica pFisica)
        {
            var pessoafisica = ObterCPF(pFisica.CPF);
            if (pessoafisica != null)
            {
                _lstPFisica.Remove(pFisica);
            }
            else
            {
                throw new ExPessoaNaoEncontrado("Cliente Inexistente"); 
            }

          
        }
        public void Alterar(Fisica pPessoaFisica)
        {
            Fisica pessoafisica = ObterCPF(pPessoaFisica.CPF);
            if (pessoafisica != null)
            {
                PropertyInfo[] campos = pessoafisica.GetType().GetProperties();
                foreach (PropertyInfo campo in campos)
                {
                    if (campo.CanWrite)
                        campo.SetValue(pessoafisica, pPessoaFisica.GetType().GetProperty(campo.Name).GetValue(pPessoaFisica, null), null);
                }
            }
            else
                throw new ExPessoaNaoEncontrado("Não possível encontrar o cliente cadastrado. ");
        }
    }

  
}
