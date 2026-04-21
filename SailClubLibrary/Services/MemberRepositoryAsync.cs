using Microsoft.Data.SqlClient;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Data;

namespace SailClubLibrary.Services
{
    public class MemberRepositoryAsync : IMemberRepositoryAsync
    {
        public MemberRepositoryAsync()
        {

        }

        public async Task AddMember(Member member)
        {
            const string query =
                @"INSERT INTO SailClubMember 
                (FirstName, SurName, PhoneNumber, MemberAddress, City, Mail, MemberType, MemberRole, MemberImage) 
                VALUES(@FirstName, @SurName, @PhoneNumber, @MemberAddress, @City, @Mail, @MemberType, @MemberRole, @MemberImage)";
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@FirstName", member.FirstName);
                command.Parameters.AddWithValue("@SurName", member.SurName);
                command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                command.Parameters.AddWithValue("@MemberAddress", member.Address);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Mail", member.Mail);
                command.Parameters.AddWithValue("@MemberType", (int)member.TheMemberType);
                command.Parameters.AddWithValue("@MemberRole", (int)member.TheMemberRole);
                command.Parameters.AddWithValue("@MemberImage", member.MemberImage ?? "");
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<List<Member>> FilterMembers(string filterCriteria)
        {
            const string query =
                @"SELECT * FROM SailClubMember 
                WHERE (MemberId, FirstName, SurName, PhoneNumber, MemberAddress, City, Mail, MemberType, MemberRole, MemberImage) 
                LIKE '%@FilterCriteria@%'";
            return await GetMembers(query);
        }

        public async Task<List<Member>> GetAllMembers()
        {
            const string query = "SELECT * FROM SailClubMember";
            return await GetMembers(query);
        }

        private async Task<List<Member>> GetMembers(string query)
        {
            List<Member> members = new();
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Member member = new(
                        reader.GetInt32("MemberId"),
                        reader.GetString("FirstName"),
                        reader.GetString("SurName"),
                        reader.GetString("PhoneNumber"),
                        reader.GetString("MemberAddress"),
                        reader.GetString("City"),
                        reader.GetString("Mail"),
                        (MemberType)reader.GetInt32("MemberType"),
                        (MemberRole)reader.GetInt32("MemberRole"),
                        reader.IsDBNull("MemberImage") ? "" : reader.GetString("MemberImage")
                    );
                    members.Add(member);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return members;
        }

        public async Task RemoveMember(Member member)
        {
            const string query =
                @"DELETE FROM SailClubMember 
                WHERE PhoneNumber=@PhoneNumber";
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@PhoneNumber", member.Id);
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task<Member?> SearchMember(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentNullException();
            }
            foreach (Member m in await GetAllMembers())
            {
                if (m.PhoneNumber.Equals(phoneNumber))
                {
                    return m;
                }
            }
            return null;
        }

        public async Task UpdateMember(Member member)
        {
            const string query =
                @"UPDATE SailClubMember 
                SET FirstName = @FirstName, SurName = @SurName, PhoneNumber = @PhoneNumber, MemberAddress = @MemberAddress, City = @City, Mail = @Mail, MemberType = @MemberType, MemberRole = @MemberRole, MemberImage = @MemberImage
                WHERE PhoneNumber = @PhoneNumber";
            try
            {
                await using SqlConnection connection = new(Connection.connectionString);
                await connection.OpenAsync();
                await using SqlCommand command = new(query, connection);
                command.Parameters.AddWithValue("@MemberId", member.Id);
                command.Parameters.AddWithValue("@FirstName", member.FirstName);
                command.Parameters.AddWithValue("@SurName", member.SurName);
                command.Parameters.AddWithValue("@PhoneNumber", member.PhoneNumber);
                command.Parameters.AddWithValue("@MemberAddress", member.Address);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Mail", member.Mail);
                command.Parameters.AddWithValue("@MemberType", (int)member.TheMemberType);
                command.Parameters.AddWithValue("@MemberRole", (int)member.TheMemberRole);
                command.Parameters.AddWithValue("@MemberImage", member.MemberImage ?? "");
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
