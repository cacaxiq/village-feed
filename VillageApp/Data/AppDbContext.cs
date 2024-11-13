using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VillageApp.Data.Entities;

namespace VillageApp.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
            UpdateDatabaseIfRequired();
        }

        private readonly int LATEST_DATABASE_VERSION = 1;

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}", o => { });
        }

        private void UpdateDatabaseIfRequired()
        {
            long currentDbVersion = Database.SqlQueryRaw<long>("PRAGMA user_version")
                                    .AsEnumerable().FirstOrDefault();

            if (LATEST_DATABASE_VERSION > currentDbVersion)
            {
                var upgradeToDbVersion = currentDbVersion + 1;

                switch (upgradeToDbVersion)
                {
                    case 1:
                        ChangePKTypePost();
                        break;
                    default:
                        Database.EnsureCreatedAsync();
                        break;
                }

                // Set the db version to latest
                var userVersionUpdate = $"PRAGMA user_version={LATEST_DATABASE_VERSION}";
                _ = Database.ExecuteSqlRaw(userVersionUpdate);
            }
        }

        private void ChangePKTypePost()
        {
            string script = """
                CREATE TABLE temp_post( 
                    Id TEXT, 
                    Title TEXT,
                    Content TEXT,
                    PRIMARY KEY (id)
                );
                INSERT INTO temp_post (Id, Title, Content)
                   SELECT Id, Title, Content FROM posts;
                DROP TABLE posts;
                ALTER TABLE temp_post RENAME TO posts;
                """;
            _ = Database.ExecuteSqlRaw(script);
        }
    }
}
