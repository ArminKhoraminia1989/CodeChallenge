using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Patient;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Requests.Commands
{
    public class UpdatePatientCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdatePatientDto Patient { get; set; }
    }
}
