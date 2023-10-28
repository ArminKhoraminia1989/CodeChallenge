using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Queries
{
    public class ShowDrugRequest : IRequest<ShowDrugDto>
    {
        public int Id { get; set; }
    }
}
