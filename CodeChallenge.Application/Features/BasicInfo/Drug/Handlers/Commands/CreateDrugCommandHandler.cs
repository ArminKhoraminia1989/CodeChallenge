using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Commands;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.Drug;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Handlers.Commands
{
    public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, BaseResponse>
    {
        private readonly IGenericRepository<Core.Entities.BasicInfo.Drug> _repDrug;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDrugDto> _Validator;
        public CreateDrugCommandHandler(IMapper mapper,
            IGenericRepository<Core.Entities.BasicInfo.Drug> repDrug,
            IValidator<CreateDrugDto> Validator)
        {
            _repDrug = repDrug;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
        {

            request.Drug.DateCreated = DateTime.Now;
            var validateReault = await _Validator.ValidateAsync(request.Drug);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var tmpDrug = _mapper.Map<Core.Entities.BasicInfo.Drug>(request.Drug);
            Expression<Func<Core.Entities.BasicInfo.Drug, bool>> queryFilter = x => x.Description == tmpDrug.Description;
            var create = await _repDrug.CreateAsync(tmpDrug, queryFilter);

            if (create.Id != 0)
            {
                response.Id = tmpDrug.Id;
                response.Message = ErrorResource.CreateSuccess;
                response.IsSuccess = true;
                response.CodeStatus = 200;
            }
            else
            {
                response.Message = ErrorResource.CreateNotSuccess;
                response.IsSuccess = false;
            }
            return response;

        }
    }
}
