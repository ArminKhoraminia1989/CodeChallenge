using CodeChallenge.Dtos.Patient;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Requests.Queries
{
    public class ShowAllPatientRequest : IRequest<ShowAllPatientDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
