using CodePulse.Domain.Models;

namespace CodePulse.Application.Interfaces
{
    public interface IBookPostRepo
    {
        Task<BookPost> CreateAsync(BookPost bookPost);

        Task<IEnumerable<BookPost>> GetAllAsync();
    }
}
