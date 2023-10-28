using AutoMapper;
using CodeChallenge.Application.Features.Appointment.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.Appointment;
using MediatR;

namespace CodeChallenge.Application.Features.Appointment.Handlers.Queries
{
    public class ShowAppointmentRequestHandler : IRequestHandler<ShowAppointmentRequest, ShowAppointmentDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Appointment> _repAppointment;
        private readonly IMapper _mapper;
        public ShowAppointmentRequestHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.Appointment> repAppointment)
        {
            _repAppointment = repAppointment;
            _mapper = mapper;
        }

        public async Task<ShowAppointmentDto> Handle(ShowAppointmentRequest request, CancellationToken cancellationToken)
        {
            var show = await _repAppointment.GetById(request.Id);
            return _mapper.Map<ShowAppointmentDto>(show);
        }
    }
}
