using Microsoft.Data.SqlClient;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Data;

namespace SailClubLibrary.Services
{
    public class BoatRepositoryAsync : IBoatRepositoryAsync
    {
        public BoatRepositoryAsync()
        {

        }

        public async Task AddBoat(Boat boat)
        {
            string query =
                @"INSERT INTO Boat 
                VALUES(@BoatId, @Model, @SailNumber, @EngineInfo, @Draft, @Width, @BoatLength, @YearOfConstruction, @BoatType)";
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@BoatId", boat.Id);
                command.Parameters.AddWithValue("@Model", boat.Model);
                command.Parameters.AddWithValue("@SailNumber", boat.SailNumber);
                command.Parameters.AddWithValue("@EngineInfo", boat.EngineInfo);
                command.Parameters.AddWithValue("@Draft", boat.Draft);
                command.Parameters.AddWithValue("@Width", boat.Width);
                command.Parameters.AddWithValue("@BoatLength", boat.Length);
                command.Parameters.AddWithValue("@YearOfConstruction", boat.YearOfConstruction);
                command.Parameters.AddWithValue("@BoatType", boat.TheBoatType);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<List<Boat>> FilterBoats(string filterCriteria)
        {
            const string query = "SELECT * FROM Boat WHERE Model LIKE '%@FilterCriteria@%'";
            return await GetBoats(query);
        }

        public async Task<List<Boat>> GetAllBoats()
        {
            const string query = "SELECT * FROM Boat";
            return await GetBoats(query);
        }

        private async Task<List<Boat>> GetBoats(string query)
        {
            List<Boat> filteredBoats = new();
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Boat boat = new(
                        reader.GetInt32("Id"),
                        (BoatType)reader.GetInt32("BoatType"),
                        reader.GetString("Model"),
                        reader.GetString("SailNumber"),
                        reader.GetString("EngineInfo"),
                        reader.GetDouble("Draft"),
                        reader.GetDouble("Width"),
                        reader.GetDouble("BoatLength"),
                        reader.GetString("YearOfConstruction")
                    );
                    filteredBoats.Add(boat);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return filteredBoats;
        }

        public async Task RemoveBoat(string sailNumber)
        {
            const string query = "DELETE FROM Boat * WHERE SailNumber=@SailNumber";
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@SailNumber", sailNumber);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Boat?> SearchBoat(string sailNumber)
        {
            foreach (Boat b in await GetAllBoats())
            {
                if (b.SailNumber.Equals(sailNumber))
                {
                    return b;
                }
            }
            return null;
        }

        //TODO
        public async Task UpdateBoat(Boat boat)
        {
            throw new NotImplementedException();
        }
    }
}
