using Global.Data;

namespace Global.Web.Models
{
    public class CategoryViewModel
    {
        public CategoryDto Entity { get; set; }

        public CategoryViewModel(CategoryDto entity)
        {
            Entity = entity;
        }

        public bool IsSelected { get; set; }
    }
}