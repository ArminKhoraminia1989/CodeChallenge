using CodeChallenge.Application.Features.AppointmentDrug.Requests.Commands;
using CodeChallenge.Application.Features.AppointmentDrug.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AppointmentDrugController : ControllerBase
    {

        private readonly IMediator _mediator;
        public AppointmentDrugController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowAppointmentDrugDto>> ShowAppointmentDrug(int id)
        {
            return await _mediator.Send(new ShowAppointmentDrugRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllAppointmentDrugDto>> ShowAllAppointmentDrug(int page, int take)
        {
            return await _mediator.Send(new ShowAllAppointmentDrugRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateAppointment(CreateAppointmentDrugDto AppointmentDrug)
        {
            return await _mediator.Send(new CreateAppointmentDrugCommand() { AppointmentDrug = AppointmentDrug });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateAppointmentDrug(UpdateAppointmentDrugDto AppointmentDrug)
        {
            return await _mediator.Send(new UpdateAppointmentDrugCommand() { AppointmentDrug = AppointmentDrug });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteAppointmentDrug(DeleteAppointmentDrugDto AppointmentDrug)
        {
            return await _mediator.Send(new DeleteAppointmentDrugCommand() { AppointmentDrug = AppointmentDrug });
        }

        #endregion
    }
}
