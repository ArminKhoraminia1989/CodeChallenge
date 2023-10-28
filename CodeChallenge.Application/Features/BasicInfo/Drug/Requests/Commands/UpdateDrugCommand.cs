using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Commands
{
    public class UpdateDrugCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateDrugDto Drug { get; set; }
    }
}
