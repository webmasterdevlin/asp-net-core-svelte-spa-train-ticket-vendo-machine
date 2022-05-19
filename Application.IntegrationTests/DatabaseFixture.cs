using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TrainTicketMachine.Data.Contexts;

namespace Application.IntegrationTests;

 public class DatabaseFixture : IDisposable
    {
        private readonly SqliteConnection _connection;
        public DatabaseFixture()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
        }
        public void Dispose() => _connection.Dispose();
        public ApplicationDbContext CreateContext()
        {
            var result = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(_connection)
                .Options);
            result.Database.EnsureCreated();
            return result;
        }
    }