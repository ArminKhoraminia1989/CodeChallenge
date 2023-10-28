using AutoMapper;
using CodeChallenge.Application.Features.Doctor.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.Doctor;
using MediatR;

namespace CodeChallenge.Application.Features.Doctor.Handlers.Queries
{
    public class ShowAllDoctorRequestHandler : IRequestHandler<ShowAllDoctorRequest, ShowAllDoctorDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Doctor> _repDoctor;
        private readonly IMapper _mapper;
        public ShowAllDoctorRequestHandler(IMapper mapper, 
            IGenericRepository<CodeChallenge.Core.Entities.Doctor> repDoctorType)
        {
            _repDoctor = repDoctorType;
            _mapper = mapper;
        }

        public async Task<ShowAllDoctorDto> Handle(ShowAllDoctorRequest request, CancellationToken cancellationToken)
        {
            ShowAllDoctorDto ShowAll = new ShowAllDoctorDto();
            ShowAll.list = _mapper.Map<List<ShowDoctorDto>>(await _repDoctor.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
