using System.ComponentModel.DataAnnotations;

namespace CodePulse.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Urlhandle { get; set; } = string.Empty;

        public ICollection<BookPost> RBookPost { get; set; } 
    }
}//when you are sure of the model, do fluent validation