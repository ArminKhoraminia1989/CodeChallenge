using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Queries
{
    public class ShowAllDrugRequest : IRequest<ShowAllDrugDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
