using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApp.Models.Entities
{
    public class VoteRepository : IVoteRepository
    {
        string connectionString = null;
        public VoteRepository(string conn)
        {
            connectionString = conn;
        }

        public List<Vote> GetVote()
        {
            using (var db = new SqliteConnection(connectionString))
            {
                db.Open();
                return db.Query<Vote>("SELECT * FROM Vote").ToList();
            }
        }

        public Vote Get(int id)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                return db.Query<Vote>("SELECT * FROM Vote WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Vote user)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Vote (Name, OptionId) VALUES(@Name, @OptionId)";
                db.Execute(sqlQuery, user);
            }
        }

        public void Update(Vote user)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "UPDATE Vote SET Name = @Name, OptionId = @OptionId WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Vote WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public List<VoteResult> GetVoteResult()
        {
            using (IDbConnection db = new SqliteConnection(connectionString))
            {
                return db.Query<VoteResult>("SELECT Options.Name AS NameOption, COUNT(Vote.Id) AS CountVotes FROM Vote INNER JOIN Options ON Vote.OptionId = Options.Id GROUP BY Options.Id, Options.Name").ToList();
            }
        }
    }
}
