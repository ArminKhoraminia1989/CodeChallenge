using CodeChallenge.Application.Features.Doctor.Requests.Commands;
using CodeChallenge.Application.Features.Doctor.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Doctor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowDoctorDto>> ShowDoctor(int id)
        {
            return await _mediator.Send(new ShowDoctorRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllDoctorDto>> ShowAllDoctor(int page, int take)
        {
            return await _mediator.Send(new ShowAllDoctorRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateDoctor(CreateDoctorDto Doctor)
        {
            return await _mediator.Send(new CreateDoctorCommand() { Doctor = Doctor });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateDoctor(UpdateDoctorDto Doctor)
        {
            return await _mediator.Send(new UpdateDoctorCommand() { Doctor = Doctor });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteDoctor(DeleteDoctorDto Doctor)
        {
            return await _mediator.Send(new DeleteDoctorCommand() { Doctor = Doctor });
        }

        #endregion
    }
}
