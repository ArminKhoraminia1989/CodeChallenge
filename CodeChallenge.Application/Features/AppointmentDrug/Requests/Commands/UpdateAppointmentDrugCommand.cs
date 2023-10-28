using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Requests.Commands
{
    public class UpdateAppointmentDrugCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public UpdateAppointmentDrugDto AppointmentDrug { get; set; }
    }
}
