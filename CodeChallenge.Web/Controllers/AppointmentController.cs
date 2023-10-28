using CodeChallenge.Application.Features.Appointment.Requests.Commands;
using CodeChallenge.Application.Features.Appointment.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Appointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowAppointmentDto>> ShowAppointment(int id)
        {
            return await _mediator.Send(new ShowAppointmentRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllAppointmentDto>> ShowAllAppointment(int page, int take)
        {
            return await _mediator.Send(new ShowAllAppointmentRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateAppointment(CreateAppointmentDto Appointment)
        {
            return await _mediator.Send(new CreateAppointmentCommand() { Appointment = Appointment });
        }

        [Route("SetAppointment")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> SetAppointment(int Doctor,int Patient 
            , int DurationonMinutes,DateTime StartDateTime)
        {
            return await _mediator.Send(new SetAppointmentCommand() 
            { Doctor = Doctor , Patient = Patient , DurationonMinutes = DurationonMinutes
            , StartDateTime = StartDateTime });
        }

        [Route("SetEarliestAppointment")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> SetEarliestAppointment(int Doctor, int Patient , int DurationonMinutes)
        {
            return await _mediator.Send(new SetEarliestAppointmentCommand()
            {
                Doctor = Doctor,
                Patient = Patient,
                DurationonMinutes = DurationonMinutes
            });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateAppointment(UpdateAppointmentDto Appointment)
        {
            return await _mediator.Send(new UpdateAppointmentCommand() { Appointment = Appointment });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteAppointment(DeleteAppointmentDto Appointment)
        {
            return await _mediator.Send(new DeleteAppointmentCommand() { Appointment = Appointment });
        }

        #endregion
    }
}
