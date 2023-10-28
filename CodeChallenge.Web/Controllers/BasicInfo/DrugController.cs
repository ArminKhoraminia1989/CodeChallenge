using CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Commands;
using CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Queries;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Web.Controllers.BasicInfo
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DrugController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DrugController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Queries

        [Route("Show")]
        [HttpGet]
        public async Task<ActionResult<ShowDrugDto>> ShowDrug(int id)
        {
            return await _mediator.Send(new ShowDrugRequest() { Id = id });
        }

        [Route("ShowAll")]
        [HttpGet]
        public async Task<ActionResult<ShowAllDrugDto>> ShowAllDrug(int page, int take)
        {
            return await _mediator.Send(new ShowAllDrugRequest() { page = page, take = take });
        }

        #endregion

        #region Commands

        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CreateDrug(CreateDrugDto Drug)
        {
            return await _mediator.Send(new CreateDrugCommand() { Drug = Drug });
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UpdateDrug(UpdateDrugDto Drug)
        {
            return await _mediator.Send(new UpdateDrugCommand() { Drug = Drug });
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DeleteDrug(DeleteDrugDto Drug)
        {
            return await _mediator.Send(new DeleteDrugCommand() { Drug = Drug });
        }

        #endregion
    }
}
