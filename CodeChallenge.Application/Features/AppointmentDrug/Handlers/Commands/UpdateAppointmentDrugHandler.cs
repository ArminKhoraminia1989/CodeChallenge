using AutoMapper;
using CodeChallenge.Application.Features.AppointmentDrug.Requests.Commands;
using CodeChallenge.Application.Repository;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.AppointmentDrug;
using FluentValidation;
using MediatR;

namespace CodeChallenge.Application.Features.AppointmentDrug.Handlers.Commands
{
    public class UpdateAppointmentDrugCommandHandler : IRequestHandler<UpdateAppointmentDrugCommand, BaseResponse>
    {
        private readonly IAppointmentDrugRepository _repAppointmentDrug;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateAppointmentDrugDto> _Validator;
        public UpdateAppointmentDrugCommandHandler(IMapper mapper,
            IAppointmentDrugRepository repAppointmentDrug,
            IValidator<UpdateAppointmentDrugDto> Validator)
        {
            _repAppointmentDrug = repAppointmentDrug;
            _mapper = mapper;
            _Validator = Validator;
        }

        public async Task<BaseResponse> Handle(UpdateAppointmentDrugCommand request, CancellationToken cancellationToken)
        {

            var validateReault = await _Validator.ValidateAsync(request.AppointmentDrug);
            BaseResponse response = new BaseResponse();
            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var tmpAppointmentDrug = _mapper.Map<CodeChallenge.Core.Entities.AppointmentDrug>(request.AppointmentDrug);
            var UpdateResponse = await _repAppointmentDrug.UpdateAsync(tmpAppointmentDrug);

            return UpdateResponse;

        }
    }
}
