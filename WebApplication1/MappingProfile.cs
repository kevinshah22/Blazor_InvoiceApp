using AutoMapper;
using BlazorApp.ViewModel;

namespace WebApplication1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlazorApp.Data.Models.Category, CategoryModel>().ReverseMap();
            CreateMap<BlazorApp.Data.Models.Store, StoreModel>().ReverseMap();
            CreateMap<BlazorApp.Data.Models.Item, ItemModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryData != null ? src.CategoryData.Name : string.Empty))
                .ReverseMap();

            CreateMap<BlazorApp.Data.Models.Invoice, InvoiceModel>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.StoreData != null ? src.StoreData.Name : string.Empty))
                .ReverseMap();

            CreateMap<BlazorApp.Data.Models.InvoiceItem, InvoiceItemModel>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemData != null ? src.ItemData.Name : string.Empty))
                .ReverseMap();

            CreateMap<BlazorApp.Data.Models.JobApplication, JobApplicationModel>().ReverseMap();
        }
    }
}
