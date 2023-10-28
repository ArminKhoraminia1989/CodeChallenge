using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Requests.Commands
{
    public class DeleteAppointmentDrugCommand : IRequest<BaseResponse>
    {
        public DeleteAppointmentDrugDto AppointmentDrug { get; set; }
    }
}
