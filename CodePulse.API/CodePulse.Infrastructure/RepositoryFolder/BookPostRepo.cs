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

        public async Task<BookPost?>  DeleteAsync(Guid Id)
        {
           var del = await _applicationDbContext.BookPosts.FirstOrDefaultAsync(x => x.Id == Id);

            if (del != null)
            {
                _applicationDbContext.BookPosts.Remove(del);
               await _applicationDbContext.SaveChangesAsync();
                return del;
            }
            return null;
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

        public async Task<BookPost> Update(Guid Id, BookPost bookPost)
        {
            var updatebyid = await _applicationDbContext.BookPosts.Include(x => x.RCategory).FirstOrDefaultAsync(item => item.Id == bookPost.Id);

            if (updatebyid == null)
            {
                return null;
            }

            //update blogpost
               _applicationDbContext.Entry(updatebyid).CurrentValues.SetValues(bookPost);
            
            //update categories

            updatebyid.RCategory = bookPost.RCategory;

            await _applicationDbContext.SaveChangesAsync();
            return bookPost;
        }
    }
}
