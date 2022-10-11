using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Querys.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Querys.ProgrammingLanguageListCommand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            ProgrammingLanguageListQuery programmingLanguageListQuery = new() { PageRequest = pageRequest };

            ProgrammingLanguagesListModel result = await Mediator!.Send(programmingLanguageListQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguagesQuery getByIdProgrammingLanguagesQuery)
        {
            GetByIdProgrammingLanguages result = await Mediator!.Send(getByIdProgrammingLanguagesQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreateProgrammingLanguagesDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguagesCommand updateProgrammingLanguagesCommand)
        {
            UpdateProgrammingLanguagesDto result = await Mediator.Send(updateProgrammingLanguagesCommand);
            return Ok(result);
        }

        [HttpDelete] 
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguagesCommand)
        {
            DeleteProgrammingLanguagesDto result = await Mediator.Send(deleteProgrammingLanguagesCommand);
            return Ok(result);
        }

        
    }
}
