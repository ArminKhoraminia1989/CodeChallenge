using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Commands;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers.BasicInfo
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DoctorTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowDoctorTypeDto>> ShowDoctorType(int id)
        {
            return await _mediator.Send(new ShowDoctorTypeRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllDoctorTypeDto>> ShowAllDoctorType(int page, int take)
        {
            return await _mediator.Send(new ShowAllDoctorTypeRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateDoctorType(CreateDoctorTypeDto DoctorType)
        {
            return await _mediator.Send(new CreateDoctorTypeCommand() { DoctorType = DoctorType });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateDoctorType(UpdateDoctorTypeDto DoctorType)
        {
            return await _mediator.Send(new UpdateDoctorTypeCommand() { DoctorType = DoctorType });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteDoctorType(DeleteDoctorTypeDto DoctorType)
        {
            return await _mediator.Send(new DeleteDoctorTypeCommand() { DoctorType = DoctorType });
        }

        #endregion
    }
}
