using CodePulse.Domain.Models;

namespace CodePulse.Application.Interfaces
{
    public interface ICategoryRepo
    {
        Task<Category> CreateAsync(Category category);
        //this will take Category and insert it in the data base and return a category.
    }
}
