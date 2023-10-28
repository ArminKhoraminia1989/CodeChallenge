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
    public class DeleteAppointmentDrugHandler
    {
        public class DeleteAppointmentDrugCommandHandler : IRequestHandler<DeleteAppointmentDrugCommand, BaseResponse>
        {
            private readonly IAppointmentDrugRepository _repAppointmentDrug;
            private readonly IMapper _mapper;
            private readonly IValidator<DeleteAppointmentDrugDto> _Validator;
            public DeleteAppointmentDrugCommandHandler(IMapper mapper,
                IAppointmentDrugRepository repAppointmentDrug,
                IValidator<DeleteAppointmentDrugDto> Validator)
            {
                _repAppointmentDrug = repAppointmentDrug;
                _mapper = mapper;
                _Validator = Validator;
            }

            public async Task<BaseResponse> Handle(DeleteAppointmentDrugCommand request, CancellationToken cancellationToken)
            {

                var validateReault = await _Validator.ValidateAsync(request.AppointmentDrug);
                BaseResponse response = new BaseResponse();

                if (!validateReault.IsValid)
                {
                    response.Message = ErrorResource.ValidationError;
                    response.IsSuccess = false;
                }
                else
                {
                    response = await _repAppointmentDrug.DeleteAsync(request.AppointmentDrug.Id);
                }

                return response;
            }
        }
    }
}
