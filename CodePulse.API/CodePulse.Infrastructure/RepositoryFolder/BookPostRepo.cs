using CodePulse.Application.Interfaces;
using CodePulse.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<BookPost>> GetAllAsync()
        {
            return await _applicationDbContext.BookPosts.Include(x => x.RCategory).ToListAsync();

        }

        public async Task<BookPost> GetRegionByIdAsync(Guid id)
        {
            var getbyId = await _applicationDbContext.BookPosts.Include(x => x.RCategory).FirstOrDefaultAsync(item => item.Id == id);

            return getbyId;
        }
    }
}
