using AutoMapper;
using CodeChallenge.Application.Features.BasicInfo.Drug.Requests.Commands;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.BasicInfo.Drug;
using FluentValidation;
using MediatR;

namespace CodeChallenge.Application.Features.BasicInfo.Drug.Handlers.Commands
{
    public class DeleteDrugCommandHandler : IRequestHandler<DeleteDrugCommand, BaseResponse>
    {
        private readonly IGenericRepository<Core.Entities.BasicInfo.Drug> _repDrug;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteDrugDto> _Validator;
        public DeleteDrugCommandHandler(IMapper mapper,
            IGenericRepository<Core.Entities.BasicInfo.Drug> repDrug,
            IValidator<DeleteDrugDto> Validator)
        {
            _repDrug = repDrug;
            _mapper = mapper;
            _Validator = Validator;
        }
        public async Task<BaseResponse> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
        {
            var validateReault = await _Validator.ValidateAsync(request.Drug);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tmpDrug = _mapper.Map<Core.Entities.BasicInfo.Drug>(request.Drug);

                if (await _repDrug.DeleteAsync(tmpDrug.Id) == true)
                {
                    response.Id = tmpDrug.Id;
                    response.Message = ErrorResource.DeleteSuccess;
                    response.IsSuccess = true;
                    response.CodeStatus = 200;
                }
                else
                {
                    response.Message = ErrorResource.DeleteNotSuccess;
                    response.IsSuccess = false;
                }
            }
            
            return response;
        }
    }
}
