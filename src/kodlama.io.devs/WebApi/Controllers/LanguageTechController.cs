using Application.Features.LanguageTech.Commands.CreateLanguageTech;
using Application.Features.LanguageTech.Commands.DeleteLanguageTech;
using Application.Features.LanguageTech.Commands.UpdateLanguageTech;
using Application.Features.LanguageTech.Dtos;
using Application.Features.LanguageTech.Models;
using Application.Features.LanguageTech.Querys;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechController : BaseController
    {
        [HttpGet]

        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechQuery getListLanguageTechQuery = new() { PageRequest = pageRequest };
            LanguageTechListModel result = await Mediator!.Send(getListLanguageTechQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetLanguageTechByIdQuery getLanguageTechByIdQuery)
        {
            GetLanguageTechByIdDto result = await Mediator!.Send(getLanguageTechByIdQuery);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechCommand createLanguageTechCommand)
        {
            CreateLanguageTechDto result = await Mediator.Send(createLanguageTechCommand);
            return Ok(result);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete([FromBody] DeleteLanguageTechCommand deleteLanguageTechCommand)
        {
            DeleteLanguageTechDto result = await Mediator!.Send(deleteLanguageTechCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLanguageTech(UpdateLanguageTechCommand updateLanguageTechCommand)
        {
            UpdateLanguageTechDto result = await Mediator.Send(updateLanguageTechCommand);
            return Ok(result);
        }
    }
}
