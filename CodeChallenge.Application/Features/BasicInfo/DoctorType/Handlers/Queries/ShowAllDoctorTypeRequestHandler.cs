using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.DoctorType.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.BasicInfo.DoctorType;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.DoctorType.Handlers.Queries
{
    public class ShowAllDoctorTypeRequestHandler : IRequestHandler<ShowAllDoctorTypeRequest, ShowAllDoctorTypeDto>
    {
        private readonly IGenericRepository<Core.Entities.BasicInfo.DoctorType> _repDoctorType;
        private readonly IMapper _mapper;
        public ShowAllDoctorTypeRequestHandler(IMapper mapper, 
            IGenericRepository<Core.Entities.BasicInfo.DoctorType> repDoctorType)
        {
            _repDoctorType = repDoctorType;
            _mapper = mapper;
        }

        public async Task<ShowAllDoctorTypeDto> Handle(ShowAllDoctorTypeRequest request, CancellationToken cancellationToken)
        {
            ShowAllDoctorTypeDto ShowAll = new ShowAllDoctorTypeDto();
            ShowAll.list = _mapper.Map<List<ShowDoctorTypeDto>>( await _repDoctorType.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
