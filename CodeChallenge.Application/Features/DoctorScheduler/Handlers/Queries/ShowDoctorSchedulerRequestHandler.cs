using AutoMapper;
using CodeChallenge.Application.Features.DoctorScheduler.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.DoctorScheduler;
using MediatR;

namespace CodeChallenge.Application.Features.DoctorScheduler.Handlers.Queries
{
    public class ShowDoctorSchedulerRequestHandler : IRequestHandler<ShowDoctorSchedulerRequest, ShowDoctorSchedulerDto>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.DoctorScheduler> _repDoctorScheduler;
        private readonly IMapper _mapper;
        public ShowDoctorSchedulerRequestHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.DoctorScheduler> repDoctorScheduler)
        {
            _repDoctorScheduler = repDoctorScheduler;
            _mapper = mapper;
        }

        public async Task<ShowDoctorSchedulerDto> Handle(ShowDoctorSchedulerRequest request, CancellationToken cancellationToken)
        {
            var show = await _repDoctorScheduler.GetById(request.Id);
            return _mapper.Map<ShowDoctorSchedulerDto>(show);
        }
    }
}
