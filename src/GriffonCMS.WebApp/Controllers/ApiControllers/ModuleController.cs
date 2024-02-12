using AutoMapper;
using GriffonCMS.Domain.Models.DTOS.Modules;
using GriffonCMS.Domain.Models.Entities.Modules;
using GriffonCMS.Domain.Services;
using GriffonCMS.WebApp.Controllers.ApiControllers.Base;

namespace GriffonCMS.WebApp.Controllers.ApiControllers
{
    public class ModuleController : CrudController<ModuleService, ModuleDto, Module, int>
    {
    }
}