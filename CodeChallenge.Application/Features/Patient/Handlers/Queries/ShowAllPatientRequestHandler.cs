using AutoMapper;
using CodeChallenge.Application.Features.Patient.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.Patient;
using MediatR;
namespace CodeChallenge.Application.Features.Patient.Handlers.Queries
{
    public class ShowAllPatientRequestHandler : IRequestHandler<ShowAllPatientRequest, ShowAllPatientDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Patient> _repPatient;
        private readonly IMapper _mapper;
        public ShowAllPatientRequestHandler(IMapper mapper, 
            IGenericRepository<CodeChallenge.Core.Entities.Patient> repPatientType)
        {
            _repPatient = repPatientType;
            _mapper = mapper;
        }

        public async Task<ShowAllPatientDto> Handle(ShowAllPatientRequest request, CancellationToken cancellationToken)
        {
            ShowAllPatientDto ShowAll = new ShowAllPatientDto();
            ShowAll.list = _mapper.Map<List<ShowPatientDto>>(await _repPatient.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
