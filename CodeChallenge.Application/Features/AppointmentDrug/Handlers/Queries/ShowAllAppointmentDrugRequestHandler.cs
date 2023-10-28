using AutoMapper;
using CodeChallenge.Application.Features.AppointmentDrug.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.AppointmentDrug;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Handlers.Queries
{
    public class ShowAllAppointmentDrugRequestHandler : IRequestHandler<ShowAllAppointmentDrugRequest, ShowAllAppointmentDrugDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.AppointmentDrug> _repAppointmentDrug;
        private readonly IMapper _mapper;
        public ShowAllAppointmentDrugRequestHandler(IMapper mapper, 
            IGenericRepository<CodeChallenge.Core.Entities.AppointmentDrug> repAppointmentDrug)
        {
            _repAppointmentDrug = repAppointmentDrug;
            _mapper = mapper;
        }

        public async Task<ShowAllAppointmentDrugDto> Handle(ShowAllAppointmentDrugRequest request, CancellationToken cancellationToken)
        {
            ShowAllAppointmentDrugDto ShowAll = new ShowAllAppointmentDrugDto();
            ShowAll.list = _mapper.Map<List<ShowAppointmentDrugDto>>(await _repAppointmentDrug.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
