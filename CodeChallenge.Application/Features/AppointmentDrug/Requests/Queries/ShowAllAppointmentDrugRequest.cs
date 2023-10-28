using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Requests.Queries
{
    public class ShowAllAppointmentDrugRequest : IRequest<ShowAllAppointmentDrugDto>
    {
        public int page { get; set; }
        public int take { get; set; }
    }
}
