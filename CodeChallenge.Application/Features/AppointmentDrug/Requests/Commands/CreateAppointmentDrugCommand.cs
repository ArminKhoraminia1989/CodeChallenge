using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Requests.Commands
{
    public class CreateAppointmentDrugCommand : IRequest<BaseResponse>
    {
        public CreateAppointmentDrugDto AppointmentDrug { get; set; }
    }
}
