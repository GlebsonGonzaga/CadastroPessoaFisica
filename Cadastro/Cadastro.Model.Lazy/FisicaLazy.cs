using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cadastro.Model.Lazy
{
    public class FisicaLazy : Pessoa
    {
        private List<Telefone> telefones = null;

        public override List<Telefone> Telefones
        {
            get
            {
                return TelefonesLazy();
            }
            set
            {
                telefones = value;
            }
        }

        private List<Telefone> TelefonesLazy()
        {
            if (telefones == null)
            {
                //Vai buscar os Telefones da Pessoa quando chamar a primeira vez   
            }

            return telefones;
        }
    }
}