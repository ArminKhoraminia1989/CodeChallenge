using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Queries;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Dtos.BasicInfo.Drug;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Handlers.Queries
{
    public class ShowDrugRequestHandler : IRequestHandler<ShowDrugRequest, ShowDrugDto>
    {
        private readonly IGenericRepository<Core.Entities.BasicInfo.Drug> _repDrug;
        private readonly IMapper _mapper;
        public ShowDrugRequestHandler(IMapper mapper,
            IGenericRepository<Core.Entities.BasicInfo.Drug> repDrug)
        {
            _repDrug = repDrug;
            _mapper = mapper;
        }

        public async Task<ShowDrugDto> Handle(ShowDrugRequest request, CancellationToken cancellationToken)
        {
            var show = await _repDrug.GetById(request.Id);
            return _mapper.Map<ShowDrugDto>(show);
        }
    }
}
