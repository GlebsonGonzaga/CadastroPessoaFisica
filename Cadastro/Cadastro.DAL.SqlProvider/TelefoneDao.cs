using System;
using System.Data.SqlClient;
using Cadastro.Model;
using Cadastro.Model.Excecoes;

namespace Cadastro.DAL.SqlProvider
{
    public class TelefoneDao : BaseDao<Telefone>
    {
       
        protected override string GetSelectCommand()
        {
            return "SELECT * FROM Telefone";
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT * FROM Telefone WHERE id_cliente = '" + id + "'";
        }

      

        protected override string GetInsertCommand(Telefone tel)
        {
           
                return String.Format(
                        "INSERT INTO Telefone (id_cliente,tipoTelefone, ddd, numero) VALUES ('{0}', '{1}', '{2}','{3}')",
                        tel.Id, tel.Tipo, tel.DDD, tel.Numero);

    
        }

        protected override string GetUpdateCommand(Telefone tel)
        {
            return "UPDATE Telefone SET numero = '" + tel.Numero + "'  WHERE id_cliente = '" + tel.Id + "'";
        }

        protected override string GetDeleteCommand(Telefone tel)
        {
           
            
                return "DELETE FROM Telefone WHERE id_cliente = '" + tel.Id + "'";
            
        }


        protected override Telefone Hydrate(SqlDataReader reader)
        {

            var telefone = new Telefone(Guid.Parse(reader[0].ToString()),
                                       (reader[1].ToString()),
                                        int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()));                  
            return telefone;

        }
    }
}
