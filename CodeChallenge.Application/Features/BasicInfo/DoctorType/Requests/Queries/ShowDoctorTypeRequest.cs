using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Queries
{
    public class ShowDoctorTypeRequest : IRequest<ShowDoctorTypeDto>
    {
        public int Id { get; set; }
    }
}
