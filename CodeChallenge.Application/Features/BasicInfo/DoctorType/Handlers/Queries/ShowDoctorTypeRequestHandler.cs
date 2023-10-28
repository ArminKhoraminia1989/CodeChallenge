using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Handlers.Queries
{
    public class ShowDoctorTypeRequestHandler : IRequestHandler<ShowDoctorTypeRequest, ShowDoctorTypeDto>
    {
        private readonly IGenericRepository<Core.Entities.BasicInfo.DoctorType> _repDoctorType;
        private readonly IMapper _mapper;
        public ShowDoctorTypeRequestHandler(IMapper mapper,
            IGenericRepository<Core.Entities.BasicInfo.DoctorType> repDoctorType)
        {
            _repDoctorType = repDoctorType;
            _mapper = mapper;
        }

        public async Task<ShowDoctorTypeDto> Handle(ShowDoctorTypeRequest request, CancellationToken cancellationToken)
        {
            var show = await _repDoctorType.GetById(request.Id);
            return _mapper.Map<ShowDoctorTypeDto>(show);
        }
    }
}