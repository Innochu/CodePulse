using CodePulse.Application.Interfaces;
using CodePulse.Domain.Models;

namespace CodePulse.Infrastructure.RepositoryFolder
{
    public class BookPostRepo : IBookPostRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BookPostRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<BookPost> CreateAsync(BookPost bookPost)  //*** category == category in controller 
        {

            await _applicationDbContext.BookPosts.AddAsync(bookPost);
            if (bookPost == null )
            {
                return null;
            }
            await _applicationDbContext.SaveChangesAsync();

            return bookPost;
        }
    }
}
