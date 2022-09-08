using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GriffonCMS.Domain.Entities.About;
using GriffonCMS.Domain.Entities.Category;
using GriffonCMS.Infrastructure.Command.Abouts;
using GriffonCMS.Infrastructure.DTOS.Abouts;
using GriffonCMS.Infrastructure.DTOS.Categories;
using GriffonCMS.Infrastructure.Queries.Abouts;
using GriffonCMS.Infrastructure.Queries.Categories;

namespace GriffonCMS.Infrastructure.Maps.Abouts;
public class AboutMap : Profile
{
    public AboutMap()
    {
        CreateMap<AboutEntity, CreateAboutCommand>().ReverseMap();
        CreateMap<AboutEntity, DeleteAboutByIdCommand>().ReverseMap();
        CreateMap<AboutEntity, GetAboutQuery>().ReverseMap();
        CreateMap<AboutEntity, GetAboutDto>().ReverseMap();
    }
}
