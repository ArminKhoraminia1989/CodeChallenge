using AutoMapper;
using CodeChallenge.Application.Features.Appointment.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.Appointment;
using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Handlers.Queries
{
    public class ShowAllAppointmentRequestHandler : IRequestHandler<ShowAllAppointmentRequest, ShowAllAppointmentDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Appointment> _repAppointment;
        private readonly IMapper _mapper;
        public ShowAllAppointmentRequestHandler(IMapper mapper, 
            IGenericRepository<CodeChallenge.Core.Entities.Appointment> repAppointment)
        {
            _repAppointment = repAppointment;
            _mapper = mapper;
        }

        public async Task<ShowAllAppointmentDto> Handle(ShowAllAppointmentRequest request, CancellationToken cancellationToken)
        {
            ShowAllAppointmentDto ShowAll = new ShowAllAppointmentDto();
            ShowAll.list = _mapper.Map<List<ShowAppointmentDto>>(await _repAppointment.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
