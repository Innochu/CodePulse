using CodePulse.Domain.Models;

namespace CodePulse.Application.Interfaces
{
    public interface IBookPostRepo
    {
        Task<BookPost> CreateAsync(BookPost bookPost);

        Task<IEnumerable<BookPost>> GetAllAsync();

        Task<BookPost> GetRegionByIdAsync(Guid id);

        Task<BookPost> Update(Guid Id, BookPost bookPost);
        Task<BookPost?> DeleteAsync(Guid Id);

    }
}
