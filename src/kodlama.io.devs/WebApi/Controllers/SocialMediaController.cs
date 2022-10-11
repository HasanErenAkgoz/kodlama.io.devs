using Application.Features.SocialMedia.Commands;
using Application.Features.SocialMedia.Dtos;
using Application.Features.SocialMedia.Models;
using Application.Features.SocialMedia.Querys.GetSocialMediaById;
using Application.Features.SocialMedia.Querys.SocialMediaList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            SocialMediaListQuery socialMediaListQuery = new() { PageRequest = pageRequest };
            SocialMediaListModel result = await Mediator.Send(socialMediaListQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetSocialMediaByIdQuery getSocialMediaByIdQuery)
        {
            GetSocialMediaByIdDto result = await Mediator!.Send(getSocialMediaByIdQuery);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            CreateSocialMediaDto result = await Mediator!.Send(createSocialMediaCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            DeleteSocialMediaDto result = await Mediator!.Send(deleteSocialMediaCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            UpdateSocialMediaDto result = await Mediator!.Send(updateSocialMediaCommand);
            return Ok(result);
        }

    }
}
