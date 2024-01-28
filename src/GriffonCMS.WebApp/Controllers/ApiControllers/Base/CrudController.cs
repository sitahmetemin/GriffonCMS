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
        private readonly TService _service;
        private readonly IMapper _mapper;

        public CrudController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual JsonResult Get(TPK id)
        {
            var result = _service.GetById(id);
            if (result is null)
                NotFound();

            return Json(result);
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual JsonResult List()
        {
            var result = _service.GetAll();
            if (result is null)
                NotFound();

            return Json(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual IActionResult Create(TDto request)
        {
            var entity = _mapper.Map<TEntity>(request);

            var result = _service.Create(entity);
            if (result != Task.CompletedTask)
                BadRequest();

            return NoContent();
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public virtual IActionResult Update(TDto request)
        {
            var entity = _mapper.Map<TEntity>(request);

            var result = _service.Update(entity);
            if (result != Task.CompletedTask)
                BadRequest();

            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual IActionResult Delete(TPK id)
        {
            var result = _service.Delete(id);
            if (result != Task.CompletedTask)
                NotFound();

            return NoContent();
        }
    }
}