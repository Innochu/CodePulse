using CodePulse.Domain.Models;

namespace CodePulse.Application.Interfaces
{
    public interface ICategoryRepo
    {
        Task<Category> CreateAsync(Category category);
        //this will take Category and insert it in the data base and return a category.

        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(Guid id);   //takes the id and returns the category that matches

        Task<Category> UpdateAsync(Category category);

        Task<Category> DeleteAsync(Guid id);
    }
}
