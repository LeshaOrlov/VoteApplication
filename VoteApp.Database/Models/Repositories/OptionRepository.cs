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
                return db.Query<Option>("SELECT * FROM Option").ToList();
            }
        }

        public Option Get(int id)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                return db.Query<Option>("SELECT * FROM Option WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Option option)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Option (Name, Age) VALUES(@Name)";
                db.Execute(sqlQuery, option);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(Option option)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "UPDATE Option SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, option);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Option WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

    }
}
