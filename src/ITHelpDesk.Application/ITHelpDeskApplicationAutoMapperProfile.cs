using AutoMapper;
using ITHelpDesk.Categories;

namespace ITHelpDesk;

public class ITHelpDeskApplicationAutoMapperProfile : Profile
{
    public ITHelpDeskApplicationAutoMapperProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
    }
}
