using AutoMapper;
using CodeChallenge.Application.Features.Patient.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.Patient;
using MediatR;

namespace CodeChallenge.Application.Features.Patient.Handlers.Queries
{
    public class ShowPatientRequestHandler : IRequestHandler<ShowPatientRequest, ShowPatientDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Patient> _repPatient;
        private readonly IMapper _mapper;
        public ShowPatientRequestHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.Patient> repPatient)
        {
            _repPatient = repPatient;
            _mapper = mapper;
        }

        public async Task<ShowPatientDto> Handle(ShowPatientRequest request, CancellationToken cancellationToken)
        {
            var show = await _repPatient.GetById(request.Id);
            return _mapper.Map<ShowPatientDto>(show);
        }
    }
}
