using AutoMapper;
using ITHelpDesk.Categories;

namespace ITHelpDesk.Categories
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateUpdateCategoryDto, Category>();
        }
    }
}
