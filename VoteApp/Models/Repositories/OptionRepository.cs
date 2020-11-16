using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Models.Entities
{
    public class OptionRepository: IOptionRepository
    {
        string connectionString = null;
        public OptionRepository(string conn)
        {
            connectionString = conn;
        }

        public List<Option> GetOptions()
        {
            using (var db = new SqliteConnection(connectionString))
            {
                db.Open();
                return db.Query<Option>("SELECT * FROM Options").ToList();
            }
        }

        public Option Get(int id)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                return db.Query<Option>("SELECT * FROM Options WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Option option)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Options (Name) VALUES(@Name)";
                db.Execute(sqlQuery, option);
            }
        }

        public void Update(Option option)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "UPDATE Options SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, option);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Options WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

    }
}
