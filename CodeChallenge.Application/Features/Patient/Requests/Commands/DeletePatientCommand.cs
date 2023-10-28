using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Patient;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Requests.Commands
{
    public class DeletePatientCommand : IRequest<BaseResponse>
    {
        public DeletePatientDto Patient { get; set; }
    }
}
