using AutoMapper;
using CodeChallenge.Application.Features.DoctorScheduler.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Handlers.Queries
{
    public class ShowAllDoctorSchedulerRequestHandler : IRequestHandler<ShowAllDoctorSchedulerRequest, ShowAllDoctorSchedulerDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.DoctorScheduler> _repDoctorScheduler;
        private readonly IMapper _mapper;
        public ShowAllDoctorSchedulerRequestHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.DoctorScheduler> repDoctorSchedulerType)
        {
            _repDoctorScheduler = repDoctorSchedulerType;
            _mapper = mapper;
        }

        public async Task<ShowAllDoctorSchedulerDto> Handle(ShowAllDoctorSchedulerRequest request, CancellationToken cancellationToken)
        {
            ShowAllDoctorSchedulerDto ShowAll = new ShowAllDoctorSchedulerDto();
            ShowAll.list = _mapper.Map<List<ShowDoctorSchedulerDto>>(await _repDoctorScheduler.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
