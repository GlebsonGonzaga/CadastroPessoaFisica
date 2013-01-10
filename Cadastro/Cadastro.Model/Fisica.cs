using System;

namespace Cadastro.Model
{
    public class Fisica : Pessoa
    {
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public string Email { get; set; }
      
        private String _cpf = String.Empty;
        public String CPF
        {
            get { return _cpf; }
            set { _cpf = value; AlterarNumeroDocumento(); }
        }
       
        protected override void AlterarNumeroDocumento()
        {
            Documento = _cpf;
        }
    }

}