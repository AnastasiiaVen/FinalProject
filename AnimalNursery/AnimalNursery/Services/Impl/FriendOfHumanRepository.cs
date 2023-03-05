using AnimalNursery.Models;
using AnimalNursery.Models.Animals;
using AnimalNursery.Models.Animals.ImpBeastOfBurden;
using AnimalNursery.Models.Animals.ImpPets;
using System.Data.SQLite;

namespace AnimalNursery.Services.Impl
{
    public class FriendOfHumanRepository : IFriendOfHumanRepository
    {
        private const string connectionString = "Data Source = AnimalNursery.db; Version = 3; Pooling = true; Max Pool Size = 100;";
        public int Create(FriendOfHuman item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "INSERT INTO FriendsOfHuman(Name, Birthday, Type, Commands) VALUES(@Name, @Birthday, @Type, @Commands)";
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Parameters.AddWithValue("@Type", item.Type);
            command.Parameters.AddWithValue("@Commands", string.Join(", ", item.Commands));
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<FriendOfHuman> GetAll()
        {
            List<FriendOfHuman> list = new List<FriendOfHuman>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM FriendsOfHuman";
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FriendOfHuman friendsOfHuman = TypeOfFriendsOfHuman.create(reader.GetString(3));
                friendsOfHuman.Id = reader.GetInt32(0);
                friendsOfHuman.Name = reader.GetString(1);
                friendsOfHuman.Birthday = new DateTime(reader.GetInt64(2));
                friendsOfHuman.Type = reader.GetString(3);
                friendsOfHuman.Commands = new Models.Commands.CommandsList(reader.GetString(4));

                list.Add(friendsOfHuman);
            }

            connection.Close();
            return list;
        }
        

        public FriendOfHuman GetById(int id)
        {
            List<FriendOfHuman> list = new List<FriendOfHuman>();
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "SELECT * FROM FriendsOfHuman WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            command.Prepare();
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                FriendOfHuman friendOfHuman = TypeOfFriendsOfHuman.create(reader.GetString(3));
                friendOfHuman.Id = reader.GetInt32(0);
                friendOfHuman.Name = reader.GetString(1);
                friendOfHuman.Birthday = new DateTime(reader.GetInt64(2));
                friendOfHuman.Type = reader.GetString(3);
                friendOfHuman.Commands = new Models.Commands.CommandsList(reader.GetString(4));

                connection.Close();
                return friendOfHuman;
            }
            else
            {
                connection.Close();
                return null;
            }
        }

        public int Update(FriendOfHuman item)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(connection);
            command.CommandText = "UPDATE FriendsOfHuman SET Name = @Name, Birthday = @Birthday, Type = @Type, Commands = @Commands WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
            command.Parameters.AddWithValue("@Type", item.Type);
            command.Parameters.AddWithValue("@Commands", string.Join(", ", item.Commands));
            command.Prepare();
            int res = command.ExecuteNonQuery();
            connection.Close();
            return res;
        }
    }
}
