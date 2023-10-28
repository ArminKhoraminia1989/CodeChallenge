using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Queries
{
    public class ShowAllDoctorTypeRequest : IRequest<ShowAllDoctorTypeDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
