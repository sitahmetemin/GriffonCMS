using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GriffonCMS.Domain.Entities.Blog;
using GriffonCMS.Infrastructure.Command.Blogs;
using GriffonCMS.Infrastructure.DTOS.Blogs;
using GriffonCMS.Infrastructure.Queries.Blogs;


namespace GriffonCMS.Infrastructure.Maps.Blogs;
public class BlogMap : Profile
{
    public BlogMap()
    {
        CreateMap<BlogEntity, CreateBlogCommand>().ReverseMap();
        CreateMap<BlogEntity, DeleteBlogByIdCommand>().ReverseMap();
        CreateMap<BlogEntity, GetBlogQuery>().ReverseMap();
        CreateMap<BlogEntity, GetBlogDto>().ReverseMap();
    }
}
