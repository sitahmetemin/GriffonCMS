using AutoMapper;
using GriffonCMS.Domain.Models.Entities.Base;
using GriffonCMS.Domain.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace GriffonCMS.WebApp.Controllers.ApiControllers.Base
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CrudController<TService, TDto, TEntity, TPK> : Controller
        where TService : CrudBaseService<TEntity, TPK>
        where TEntity : BaseEntity<TPK>
        where TPK : struct
    {
        protected readonly TService Service;
        protected readonly IMapper Mapper;

        public CrudController()
        {
            Service = (TService)HttpContext.RequestServices.GetRequiredService(typeof(TService));
            Mapper = (IMapper)HttpContext.RequestServices.GetRequiredService(typeof(IMapper));
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual JsonResult Get(TPK id)
        {
            var result = Service.GetById(id);
            if (result is null)
                NotFound();

            return Json(result);
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual JsonResult List()
        {
            var result = Service.GetAll();
            if (result is null)
                NotFound();

            return Json(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual IActionResult Create(TDto request)
        {
            var entity = Mapper.Map<TEntity>(request);

            var result = Service.Create(entity);
            if (result != Task.CompletedTask)
                BadRequest();

            return NoContent();
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual IActionResult Update(TDto request)
        {
            var entity = Mapper.Map<TEntity>(request);

            var result = Service.Update(entity);
            if (result != Task.CompletedTask)
                BadRequest();

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual IActionResult Delete(TPK id)
        {
            var result = Service.Delete(id);
            if (result != Task.CompletedTask)
                NotFound();

            return NoContent();
        }
    }
}