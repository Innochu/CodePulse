using CodePulse.Application.DTO.RequestDTO;
using CodePulse.Application.Interfaces;
using CodePulse.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.Infrastructure.RepositoryFolder
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Category> CreateAsync(Category category)  //*** category == category in controller 
        {

            await _applicationDbContext.Categories.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteAsync(Guid id)
        {
           var deleteitem = await _applicationDbContext.Categories.FindAsync(id);
            if (deleteitem is null)
            {
                return null;
            }
            _applicationDbContext.Remove(deleteitem);
            await _applicationDbContext.SaveChangesAsync();
            return deleteitem;

        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
          return await _applicationDbContext.Categories.ToListAsync();
           
        }


        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id );

        }

        public async Task<Category> UpdateAsync(Category category)
        {
           var existingcategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(item => item.Id == category.Id);

            if (existingcategory != null)
            {
                 _applicationDbContext.Entry(existingcategory).CurrentValues.SetValues(category);
                await _applicationDbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
