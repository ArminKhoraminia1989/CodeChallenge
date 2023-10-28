using CodeChallenge.Application.Features.DoctorScheduler.Requests.Commands;
using CodeChallenge.Application.Features.DoctorScheduler.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DoctorSchedulerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorSchedulerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowDoctorSchedulerDto>> ShowDoctorScheduler(int id)
        {
            return await _mediator.Send(new ShowDoctorSchedulerRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllDoctorSchedulerDto>> ShowAllDoctorScheduler(int page, int take)
        {
            return await _mediator.Send(new ShowAllDoctorSchedulerRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateDoctorScheduler(CreateDoctorSchedulerDto DoctorScheduler)
        {
            return await _mediator.Send(new CreateDoctorSchedulerCommand() { DoctorScheduler = DoctorScheduler });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateDoctorScheduler(UpdateDoctorSchedulerDto DoctorScheduler)
        {
            return await _mediator.Send(new UpdateDoctorSchedulerCommand() { DoctorScheduler = DoctorScheduler });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteDoctorScheduler(DeleteDoctorSchedulerDto DoctorScheduler)
        {
            return await _mediator.Send(new DeleteDoctorSchedulerCommand() { DoctorScheduler = DoctorScheduler });
        }

        #endregion
    }
}
