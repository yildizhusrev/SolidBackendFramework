using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TmTFramework.Core.Entities;
using System.Configuration;
using System.Linq.Expressions;

namespace TmTFramework.Core.DataAccess.Dapper
{
    public class DapperHelper<T> : IDisposable
    {

        #region Excute Operations

        public object ExcuteCommand(CommandType commandType,string command, params object[] _parametreler)
        {
            using (var connection = CreateConnection())
            { 
               return connection.Execute(command,_parametreler, commandType: commandType);
            }
        }

        public dynamic QueryCommand(CommandType commandType, string command, params object[] _parametreler)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<dynamic>(command, _parametreler, commandType: commandType).ToList();
            }
        }

        #endregion


        #region Delete Operations
        public void Delete(object id)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute($"DELETE FROM {_tableName} WHERE {PrimaryKeyColumnName}=@Id", new { Id = id });
            }
        }
        public async Task DeleteRowAsync(object id)
        {
            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE {PrimaryKeyColumnName}=@Id", new { Id = id });
            }
        }

        #endregion

        #region Select Operations

        public async Task<T> GetAsync(object id)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE {PrimaryKeyColumnName}=@Id", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");

                return result;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">this filter works just only AND , OR operators</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllAsync(Expression filter = null)
        {
            using (var connection = CreateConnection())
            {
                return filter==null? 
                    await connection.QueryAsync<T>($"SELECT * FROM {_tableName}"):
                    await connection.QueryAsync<T>($"SELECT * FROM {_tableName} where {ExpressionExtensions.ToMSSqlString(filter)}");
               
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">this filter works just only AND , OR operators</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression filter = null)
        {
            using (var connection = CreateConnection())
            {
                return (filter == null) ?
                 connection.Query<T>($"SELECT * FROM {_tableName}") :
                 connection.Query<T>($"SELECT * FROM {_tableName} where {ExpressionExtensions.ToMSSqlString(filter)}");
            }
        }

        public T GetById(object id)
        {
            using (var connection = CreateConnection())
            {
                var result = connection.QuerySingleOrDefault<T>($"SELECT * FROM {_tableName} WHERE {PrimaryKeyColumnName}=@Id", new { Id = id });
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with id [{id}] could not be found.");

                return result;
            }
        }

        #endregion

        #region Insert Operation

        public async Task<int> SaveRangeAsync(IEnumerable<T> list)
        {
            
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = CreateConnection())
            {
                inserted += await connection.ExecuteAsync(query, list);
            }

            return inserted;
        }

        public int SaveRange(IEnumerable<T> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = CreateConnection())
            {
                inserted += connection.Execute(query, list);
            }
            return inserted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t">Insert Object</param>
        /// <returns>Primary Key Value</returns>
        public object Insert(T t)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = CreateConnection())
            {
                var Id = connection.ExecuteScalar(insertQuery + " SELECT SCOPE_IDENTITY() as ScopeIdentity ", t);
                //var Id = connection.Execute(insertQuery , t);
                return Id;
            }

        }

        public async Task InsertAsync(T t)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(insertQuery, t);
            }
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            if(PrimaryKeyColumnType!="Guid")
                if (!string.IsNullOrEmpty(PrimaryKeyColumnName))
                    {
                        insertQuery.Replace($"[{PrimaryKeyColumnName}],", " ");
                        insertQuery.Replace($"@{PrimaryKeyColumnName},", " ");
                    }

            return insertQuery.ToString();
        }
        #endregion

        #region Update Operations
        public void Update(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                connection.Execute(updateQuery, t);
            }
        }
        public async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(updateQuery, t);
            }
        }

        private string GenerateUpdateQuery()
        {

            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals(PrimaryKeyColumnName))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append($" WHERE {PrimaryKeyColumnName}=@{PrimaryKeyColumnName}");

            return updateQuery.ToString();
        }
        #endregion


        #region Helper Methods

        /// <summary>
        /// Generate new connection based on connection string
        /// </summary>
        /// <returns></returns>
        private SqlConnection SqlConnection()
        {
            return new SqlConnection("Data Source = 178.20.229.21; Initial Catalog = TmT.ServisTakip; User ID = TmTServis; Password = !Aq2Sw3De4!;");
            return new SqlConnection(@"Data Source=178.20.229.21; Integrated Security=true;Initial Catalog=KonferansRandevu;");
        }

        /// <summary>
        /// Open new connection and return it for use
        /// </summary>
        /// <returns></returns>
        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        private string _tableName => typeof(T).Name.ToString();
        private string PrimaryKeyColumnName => GetPKName() ;
        private string PrimaryKeyColumnType => GetPKType();

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            var result = (from prop in listOfProperties
                          let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                          where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                          select prop.Name).ToList();
            return result;
        }

        
        private string GetPKName()
        {

            var properties = GetProperties;
            Console.WriteLine("Finding PK for {0}", _tableName);
            // This replaces all the iteration above:
            var property = properties
                .FirstOrDefault(p => p.GetCustomAttributes(false)
                    .Any(a => a.GetType() == typeof(KeyAttribute)));
            if (property != null)
            {
                return property.Name;
                //string msg = "The Primary Key for the {0} class is the {1} property";
                //Console.WriteLine(msg, _tableName, property.Name);
            }
            else
            {
                throw new Exception("Primary Key Tanımlı Değil");
                return "";
            }

        }

        private string GetPKType()
        {

            var properties = GetProperties;
            Console.WriteLine("Finding PK for {0}", _tableName);
            // This replaces all the iteration above:
            var property = properties
                .FirstOrDefault(p => p.GetCustomAttributes(false)
                    .Any(a => a.GetType() == typeof(KeyAttribute)));
            if (property != null)
            {
                return property.PropertyType.Name;
                //string msg = "The Primary Key for the {0} class is the {1} property";
                //Console.WriteLine(msg, _tableName, property.Name);
            }
            else
            {
                throw new Exception("Primary Key Tanımlı Değil");
                return "";
            }

        }
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
