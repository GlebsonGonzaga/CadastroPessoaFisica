using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cadastro.DAL.SqlProvider
{
    public abstract class BaseDao<T> : IDAL<T>
    {
        public List<T> GetAll()
        {
            var entidades = new List<T>();

            using (SqlCommand command = GetCommand(GetSelectCommand()))
            {
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entidades.Add(Hydrate(reader));
                    }
                }
                command.Connection.Close();
            }

            return entidades;
        }


    

        public T Get(Guid id)
        {
            T entidade = default(T);

            using (SqlCommand command = GetCommand(GetSelectCommand(id.ToString())))
            {
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entidade = Hydrate(reader);
                    }
                }
                command.Connection.Close();
            }

            return entidade;
        }

        public void Insert(T entity)
        {
            using (SqlCommand command = GetCommand(GetInsertCommand(entity)))
            {
                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        public void Delete(T entity)
        {

            using (SqlCommand command = GetCommand(GetDeleteCommand(entity)))
            {
                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }


        public void Update(T entity)
        {

            using (SqlCommand command = GetCommand(GetUpdateCommand(entity)))
            {
                command.Connection.Open();
                int result = command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        public void SaveAll()
        {

        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Temp;Integrated Security=True");
        }

        private SqlCommand GetCommand(string command)
        {
            return new SqlCommand(command, GetConnection());
        }

        protected abstract string GetSelectCommand();
        protected abstract string GetSelectCommand(string id);
      
        protected abstract string GetInsertCommand(T entidade);
        protected abstract string GetUpdateCommand(T entidade);
        protected abstract string GetDeleteCommand(T entidade);
        protected abstract T Hydrate(SqlDataReader reader);

    }
}
