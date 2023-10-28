using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Requests.Queries
{
    public class ShowAppointmentDrugRequest : IRequest<ShowAppointmentDrugDto>
    {
        public int Id { get; set; }
    }
}
