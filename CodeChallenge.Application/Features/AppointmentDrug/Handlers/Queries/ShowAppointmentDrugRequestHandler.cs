using AutoMapper;
using CodeChallenge.Application.Features.AppointmentDrug.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Handlers.Queries
{
    public class ShowAppointmentDrugRequestHandler : IRequestHandler<ShowAppointmentDrugRequest, ShowAppointmentDrugDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.AppointmentDrug> _repAppointmentDrug;
        private readonly IMapper _mapper;
        public ShowAppointmentDrugRequestHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.AppointmentDrug> repAppointmentDrug)
        {
            _repAppointmentDrug = repAppointmentDrug;
            _mapper = mapper;
        }

        public async Task<ShowAppointmentDrugDto> Handle(ShowAppointmentDrugRequest request, CancellationToken cancellationToken)
        {
            var show = await _repAppointmentDrug.GetById(request.Id);
            return _mapper.Map<ShowAppointmentDrugDto>(show);
        }
    }
}
