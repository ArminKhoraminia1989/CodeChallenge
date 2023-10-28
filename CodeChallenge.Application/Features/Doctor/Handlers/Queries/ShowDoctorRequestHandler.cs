using AutoMapper;
using CodeChallenge.Application.Features.Doctor.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Handlers.Queries
{
    public class ShowDoctorRequestHandler : IRequestHandler<ShowDoctorRequest, ShowDoctorDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Doctor> _repDoctor;
        private readonly IMapper _mapper;
        public ShowDoctorRequestHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.Doctor> repDoctor)
        {
            _repDoctor = repDoctor;
            _mapper = mapper;
        }

        public async Task<ShowDoctorDto> Handle(ShowDoctorRequest request, CancellationToken cancellationToken)
        {
            var show = await _repDoctor.GetById(request.Id);
            return _mapper.Map<ShowDoctorDto>(show);
        }
    }
}
