using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Handlers.Queries
{
    public class ShowAllDrugRequestHandler : IRequestHandler<ShowAllDrugRequest, ShowAllDrugDto>
    {
        private readonly IGenericRepository<Core.Entities.BasicInfo.Drug> _repDrug;
        private readonly IMapper _mapper;
        public ShowAllDrugRequestHandler(IMapper mapper,
            IGenericRepository<Core.Entities.BasicInfo.Drug> repDrug)
        {
            _repDrug = repDrug;
            _mapper = mapper;
        }

        public async Task<ShowAllDrugDto> Handle(ShowAllDrugRequest request, CancellationToken cancellationToken)
        {
            ShowAllDrugDto ShowAll = new ShowAllDrugDto();
            ShowAll.list = _mapper.Map<List<ShowDrugDto>>(await _repDrug.GetAll(request.take, request.page));
            ShowAll.Count = ShowAll.list.Count();
            return ShowAll;
        }
    }
}
