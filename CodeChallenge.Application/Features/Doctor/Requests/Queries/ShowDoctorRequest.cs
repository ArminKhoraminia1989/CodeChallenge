using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Requests.Queries
{
    public class ShowDoctorRequest : IRequest<ShowDoctorDto>
    {
        public int Id { get; set; }
    }
}
