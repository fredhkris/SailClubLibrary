using SailClubLibrary.Models;

namespace SailClubLibrary.Interfaces
{
    public interface IMemberRepositoryAsync
    {
        Task AddMember(Member member);

        Task<List<Member>> FilterMembers(string filterCriteria);

        Task<List<Member>> GetAllMembers();

        Task RemoveMember(Member member);

        Task<Member?> SearchMember(string phoneNumber);

        Task UpdateMember(Member member);
    }
}