using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IBoatRepositoryAsync
    {
        Task<List<Boat>> GetAllBoats();
        Task AddBoat(Boat boat);
        Task RemoveBoat(string sailNumber);
        Task UpdateBoat(Boat boat);
        Task<Boat?> SearchBoat(string sailNumber);
        Task<List<Boat>> FilterBoats(string filterCriteria);
    }
}
