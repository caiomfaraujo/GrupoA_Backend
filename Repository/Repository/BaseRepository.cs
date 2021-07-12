using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repository.Repository
{
    public class BaseRepository
    {
        public T QueryFirst<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.QueryFirst<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Este é o StackTrace do Erro: {0}", ex);
                return default;
            }
        }

        public T QueryFirstOrDefault<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.QueryFirstOrDefault<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Este é o StackTrace do Erro: {0}", ex);
                return default;
            }
        }

        public T QuerySingle<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.QuerySingle<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Este é o StackTrace do Erro: {0}", ex);
                return default;
            }
        }

        public T QuerySingleOrDefault<T>(string query, object parameters = null)
        {
            try
            {
                using (SqlConnection conn
                       = new SqlConnection("Your Connection String"))
                {
                    return conn.QuerySingleOrDefault<T>(query, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Este é o StackTrace do Erro: {0}", ex);
                return default;
            }
        }
    }
}
