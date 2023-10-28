using CodeChallenge.Dtos.Patient;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Requests.Queries
{
    public class ShowPatientRequest : IRequest<ShowPatientDto>
    {
        public int Id { get; set; }
    }
}
