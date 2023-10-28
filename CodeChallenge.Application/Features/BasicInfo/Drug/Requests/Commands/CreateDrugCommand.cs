using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Commands
{
    public class CreateDrugCommand : IRequest<BaseResponse>
    {
        public CreateDrugDto Drug { get; set; }
    }
}
