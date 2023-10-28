using CodeChallenge.Application.Features.Patient.Requests.Commands;
using CodeChallenge.Application.Features.Patient.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Patient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowPatientDto>> ShowPatient(int id)
        {
            return await _mediator.Send(new ShowPatientRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllPatientDto>> ShowAllPatient(int page, int take)
        {
            return await _mediator.Send(new ShowAllPatientRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreatePatient(CreatePatientDto Patient)
        {
            return await _mediator.Send(new CreatePatientCommand() { Patient = Patient });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdatePatient(UpdatePatientDto Patient)
        {
            return await _mediator.Send(new UpdatePatientCommand() { Patient = Patient });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeletePatient(DeletePatientDto Patient)
        {
            return await _mediator.Send(new DeletePatientCommand() { Patient = Patient });
        }

        #endregion
    }
}
