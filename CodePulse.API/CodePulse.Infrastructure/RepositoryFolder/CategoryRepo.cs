using CodePulse.Application.DTO.RequestDTO;
using CodePulse.Application.Interfaces;
using CodePulse.Domain.Models;

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
    }
}
