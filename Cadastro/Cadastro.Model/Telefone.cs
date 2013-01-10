using System;

namespace Cadastro.Model
{
    public class Telefone : Pessoa
    {
        public String Tipo { get; set; }
        public int DDD { get; set; }
        public int Numero { get; set; }

        public Telefone(Guid id, String pTipo, int pDDD, int pNumero)
        {
            Id = id;
            Tipo = pTipo;
            DDD = pDDD;
            Numero = pNumero;
        }

      

        protected override void AlterarNumeroDocumento()
        {
         
        }
    }
}