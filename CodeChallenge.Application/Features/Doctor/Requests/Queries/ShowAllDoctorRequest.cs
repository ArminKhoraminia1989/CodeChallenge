using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Requests.Queries
{
    public class ShowAllDoctorRequest : IRequest<ShowAllDoctorDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
