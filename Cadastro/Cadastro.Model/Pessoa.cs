using System;
using System.Collections.Generic;
using System.Linq;
using Cadastro.Model.Excecoes;

namespace Cadastro.Model
{
    public abstract class Pessoa : ICloneable
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        private String _documento;
        private List<Telefone> _Telefones;
      

        public String Documento
        {
            get { return _documento; }
            protected set { _documento = value; }
        }
        public List<Telefone> Telefones
        {
            get { return _Telefones; }
        }
        protected Pessoa()
        {
            _Telefones = new List<Telefone>();
        }
        private Telefone EncontrarTelefone(int pDDD, int pNumero)
        {
            return _Telefones.Where(t => t.DDD == pDDD && t.Numero == pNumero).FirstOrDefault();
        }

        protected abstract void AlterarNumeroDocumento();
        public void AdicionarTelefone(Guid id, String pTipo, int pDDD, int pNumero)
        {
            Telefone telefone = EncontrarTelefone( pDDD, pNumero);

            if (telefone != null)
                throw new ExTelefoneExistente("Telefone existente");
            else
            {
                telefone = new Telefone(id,pTipo, pDDD, pNumero);
                _Telefones.Add(telefone);
            }
        }
        public void ExcluirTelefone(int pDDD, int pNumero)
        {
            Telefone telefone = EncontrarTelefone(pDDD, pNumero);

            if (telefone == null)
            {
                throw new ExTelefoneInexistente("Telefone inexistente");
            }

            _Telefones.Remove(telefone);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}