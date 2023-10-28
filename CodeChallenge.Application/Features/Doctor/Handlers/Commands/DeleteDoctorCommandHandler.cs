using AutoMapper;
using CodeChallenge.Application.Features.Doctor.Requests.Commands;
using CodeChallenge.Data.Repository.BasicInfo;
using CodeChallenge.Application.Resources;
using CodeChallenge.Application.Responses;
using CodeChallenge.Dtos.Doctor;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace CodeChallenge.Application.Features.Doctor.Handlers.Commands
{
    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, BaseResponse>
    {
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Doctor> _repDoctor;
        private readonly IGenericRepository<CodeChallenge.Core.Entities.Appointment> _repAppointment;
        private readonly IGenericRepository<CodeChallenge.Core.Entities.DoctorScheduler> _repDoctorScheduler;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteDoctorDto> _Validator;
        public DeleteDoctorCommandHandler(IMapper mapper,
            IGenericRepository<CodeChallenge.Core.Entities.Doctor> repDoctor,
            IGenericRepository<CodeChallenge.Core.Entities.Appointment> repAppointment,
            IGenericRepository<CodeChallenge.Core.Entities.DoctorScheduler> repDoctorScheduler,
            IValidator<DeleteDoctorDto> Validator)
        {
            _repDoctor = repDoctor;
            _repAppointment = repAppointment;
            _repDoctorScheduler = repDoctorScheduler;
            _mapper = mapper;
            _Validator = Validator;
        }
        public async Task<BaseResponse> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var validateReault = await _Validator.ValidateAsync(request.Doctor);
            BaseResponse response = new BaseResponse();

            if (!validateReault.IsValid)
            {
                response.Message = ErrorResource.ValidationError;
                response.IsSuccess = false;
                response.Errors = validateReault.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                // چک کردن وجود نداشتن برنامه ی کاری برای این پزشک
                Expression<Func<CodeChallenge.Core.Entities.DoctorScheduler, bool>> SchedulerFilter = x =>
                x.DoctorId == request.Doctor.Id;
                if (await _repDoctorScheduler.ExistFilter(SchedulerFilter))
                {
                    response.Message = ErrorResource.SchedulerExist;
                    response.IsSuccess = false;
                    return response;
                }

                // چک کردن وجود نداشتن وقت ویزیت برای این پزشک
                Expression<Func<CodeChallenge.Core.Entities.Appointment, bool>> AppointmentFilter = x =>
                x.DoctorId == request.Doctor.Id;
                if (await _repAppointment.ExistFilter(AppointmentFilter))
                {
                    response.Message = ErrorResource.AppointmentExist;
                    response.IsSuccess = false;
                    return response;
                }

                if (await _repDoctor.DeleteAsync(request.Doctor.Id) == true)
                {
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
