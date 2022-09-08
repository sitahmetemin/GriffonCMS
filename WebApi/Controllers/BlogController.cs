using GriffonCMS.Infrastructure.Command;
using GriffonCMS.Infrastructure.Command.Blogs;
using GriffonCMS.Infrastructure.Queries.Blogs;
using GriffonCMS.Infrastructure.Queries.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{

    private IMediator _mediator;


    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetBlogQuery();
        return Ok(await Mediator.Send(query));
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateBlogCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await Mediator.Send(new DeleteBlogByIdCommand { Id = id }));
    }
}
