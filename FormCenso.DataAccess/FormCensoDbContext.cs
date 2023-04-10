using FormCenso.DataAccess.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



namespace FormCenso.DataAccess
{
    class FormCensoDbContext : FormcensoContext
    {
        public static string ConnectionString { get; set; }

        public FormCensoDbContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilders)
        {
            if (!optionsBuilders.IsConfigured)
            {
                optionsBuilders.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilders);
        }

        public static void BuildConnectionString(string connectionString)
        {
            var connString = new SqlConnectionStringBuilder
            {
                ConnectionString = connectionString
            };
            ConnectionString = connString.ConnectionString;
        }
    }
}
