using AnimalNursery.Services;
using AnimalNursery.Services.Impl;
using System.Data.SQLite;

namespace AnimalNursery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ConfigureSqlLiteConnection();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped <IFriendOfHumanRepository, FriendOfHumanRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        private static void ConfigureSqlLiteConnection()
        {
            string connectionString = "Data Source = AnimalNursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";
            SQLiteConnection sQLiteConnection = new SQLiteConnection(connectionString);
            sQLiteConnection.Open();
            PrepareSchema(sQLiteConnection);
        }

        private static void PrepareSchema(SQLiteConnection sQLiteConnection)
        {
            SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
            sQLiteCommand.CommandText = "DROP TABLE IF EXISTS FriendsOfHuman";
            sQLiteCommand.ExecuteNonQuery();
            sQLiteCommand.CommandText =
                    @"CREATE TABLE FriendsOfHuman(
                    Id INTEGER PRIMARY KEY,
                    Name TEXT,
                    Birthday INTEGER,
                    Type VARCHAR(45),
                    Commands TEXT)";
            sQLiteCommand.ExecuteNonQuery();


        }
    }
}