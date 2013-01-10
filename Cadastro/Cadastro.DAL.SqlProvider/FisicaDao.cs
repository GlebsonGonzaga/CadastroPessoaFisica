using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cadastro.Model;

namespace Cadastro.DAL.SqlProvider
{
    public class FisicaDao : BaseDao<Fisica>
    {

        protected override string GetUpdateCommand(Fisica entidade)
        {
            return "UPDATE Fisica SET nome = '" + entidade.Nome + "'  WHERE id_cliente = '" + entidade.Id + "'";
        }

        protected override string GetDeleteCommand(Fisica entidade)
        {
            return "DELETE FROM Fisica WHERE id_cliente = '" + entidade.Id + "'";
        }

        protected override string GetInsertCommand(Fisica entidade)
        {
            return String.Format("INSERT INTO Fisica (id_cliente, nome, idade, sexo, email, cpf) VALUES ('{0}', '{1}', {2}, '{3}','{4}','{5}')",
                entidade.Id, entidade.Nome, entidade.Idade, entidade.Sexo,entidade.Email,entidade.CPF);
        }

        protected override string GetSelectCommand()
        {
            return "SELECT * FROM Fisica";
        }

        protected override string GetSelectCommand(string id)
        {
            return "SELECT * FROM Fisica WHERE id_cliente = '" + id + "'";
        }

       

        protected override Fisica Hydrate(SqlDataReader reader)
        {
            var fisica = new Fisica
                             {
                                 Id = Guid.Parse(reader[0].ToString()),
                                 Nome = reader[1].ToString(),
                                 Idade = int.Parse(reader[2].ToString()),
                                 Sexo = char.Parse(reader[3].ToString()),
                                 Email = reader[4].ToString(),
                                 CPF = reader[5].ToString()
                             };

            //T.Telefones = ???
            

            return fisica;
        }
    }
}