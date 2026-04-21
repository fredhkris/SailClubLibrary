using Microsoft.Data.SqlClient;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System.Data;

namespace SailClubLibrary.Services
{
    //TODO
    public class BookingRepositoryAsync /*: IBookingRepositoryAsync*/
    {
        //    private List<Booking> _bookings;

        //    public BookingRepositoryAsync()
        //    {
        //    }

        //    public async Task AddBooking(Booking booking)
        //    {
        //        const string query =
        //            @"INSERT INTO Booking 
        //            (StartDate, EndDate, SailCompleted, Destination, MemberId, BoatId) 
        //            VALUES(@StartDate, @EndDate, @SailCompleted, @Destination, @MemberId, @BoatId)";
        //        try
        //        {
        //            await using SqlConnection connection = new(Connection.connectionString);
        //            await connection.OpenAsync();
        //            await using SqlCommand command = new(query, connection);
        //            command.Parameters.AddWithValue("@StartDate", booking.StartDate);
        //            command.Parameters.AddWithValue("@EndDate", booking.EndDate);
        //            command.Parameters.AddWithValue("@SailCompleted", booking.SailCompleted);
        //            command.Parameters.AddWithValue("@Destination", booking.Destination);
        //            command.Parameters.AddWithValue("@MemberId", booking.TheMember.Id);
        //            command.Parameters.AddWithValue("@BoatId", booking.TheBoat.Id);
        //            int rows = await command.ExecuteNonQueryAsync();
        //            if (rows > 0)
        //            {
        //                _bookings.Add(booking);
        //            }
        //            await command.ExecuteNonQueryAsync();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //    }

        //    public async Task<List<Booking>> GetAllBookings()
        //    {
        //        const string query = "SELECT * FROM SailClubMember";
        //        return await GetBookings(query);
        //    }

        //    private async Task<List<Booking>> GetBookings(string query)
        //    {
        //        List<Booking> bookings = new();
        //        try
        //        {
        //            await using SqlConnection connection = new(connectionString);
        //            await connection.OpenAsync();
        //            await using SqlCommand command = new(query, connection);
        //            await using SqlDataReader reader = await command.ExecuteReaderAsync();
        //            while (await reader.ReadAsync())
        //            {
        //                Booking booking = new(
        //                    reader.GetInt32("BookingId"),
        //                    reader.GetDateTime("StartDate"),
        //                    reader.GetDateTime("EndDate"),
        //                    reader.GetString("Destination"),
        //                    reader.GetInt32("MemberId"),
        //                    reader.GetInt32("BoatId")
        //                );
        //                booking.SailCompleted = reader.GetBoolean("SailCompleted");
        //                bookings.Add(booking);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }
        //        return bookings;
        //    }

        //    public async Task<Dictionary<string, int>> GetAllBookingsForMembers()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<int> GetBookingCountForMember(Member member)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task PrintAll()
        //    {
        //        foreach (Booking b in await GetAllBookings())
        //        {
        //            Console.WriteLine(b);
        //        }
        //        throw new NotImplementedException();
        //    }

        //    public async Task RemoveBooking(Booking b)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    // TODO
        //    public async Task UpdateBooking(int id, Booking newBooking)
        //    {
        //        throw new NotImplementedException();
        //    }
    }
}