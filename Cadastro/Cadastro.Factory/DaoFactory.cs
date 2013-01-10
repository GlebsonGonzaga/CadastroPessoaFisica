using Cadastro.DAL;
using Cadastro.DAL.SqlProvider;
using Cadastro.Model;

namespace Cadastro.Factory
{
    public static class DaoFactory
    {
        public static IDAL<Fisica> GetFisicaDao()
        {
            return new FisicaDao();
        }
        public static IDAL<Telefone> GetTelefoneDao()
        {
            return new TelefoneDao();
        }
      
    }
}